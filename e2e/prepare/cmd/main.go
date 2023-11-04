package main

import (
	"fmt"
	"os"
)

func main() {
	url := os.Getenv("url")
	fmt.Println(url)
}
