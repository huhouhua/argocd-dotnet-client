package main

import (
	"encoding/json"
	"errors"
	"fmt"
	"io"
	"net/http"
	"os"
	"strings"
)

const (
	userNameTag = "argocd_username"
	passwordTag = "argocd_password"
)

var argocdUserName = os.Getenv(userNameTag)
var argocdPassWord = os.Getenv(passwordTag)

type LoginService struct {
	userName string `json:"username"`
	passWord string `json:"password"`
}

func newLoginService() *LoginService {
	if strings.TrimSpace(argocdUserName) == "" {
		panic(fmt.Sprintf("argo cd %s environment variable can not be empty！please set the %s environment variable", userNameTag, userNameTag))
	}
	if strings.TrimSpace(argocdPassWord) == "" {
		panic(fmt.Sprintf("argo cd %s environment variable can not be empty！please set the %s environment variable", argocdPassWord, argocdPassWord))
	}
	return &LoginService{
		userName: argocdUserName,
		passWord: argocdPassWord,
	}
}

func (a *LoginService) Login() (*LoginResponse, error) {
	data, err := json.Marshal(a)
	if err != nil {
		return nil, err
	}
	payload := strings.NewReader(string(data))
	req, err := http.NewRequest(http.MethodPost, fmt.Sprintf("%s/api/v1/session", BaseUrl), payload)
	if err != nil {
		return nil, err
	}
	req.Header.Add("Content-Type", "application/json")
	client := &http.Client{Transport: http.DefaultTransport}

	resp, err := client.Do(req)
	if resp != nil {
		defer resp.Body.Close()
	}
	if err != nil {
		return nil, err
	}
	bytes, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, err
	}
	if resp.StatusCode != http.StatusOK {
		return nil, errors.New(fmt.Sprintf("login fail! response http status is %d, message %s", resp.StatusCode, bytes))
	}
	var response = LoginResponse{}
	err = json.Unmarshal(bytes, &response)
	if err != nil {
		return nil, err
	}
	return &response, nil
}

type LoginResponse struct {
	Token string `json:"token"`
}
