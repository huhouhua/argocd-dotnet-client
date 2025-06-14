using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArgoCD.Client.Test;

public class DataTest
{
    // [Fact]
    //
    // public async Task DataTest1()
    // {
    //     var handler = new HttpClientHandler()
    //     {
    //         ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
    //     };
    //     var client = new HttpClient(handler);
    //     var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:30080/api/v1/session");
    //     request.Headers.Add("accept", "application/json");
    //     var content =
    //         new StringContent("{\r\n    \"username\":\"admin\",\r\n    \"password\":\"0gN-QAekD8meAq6c\"\r\n}");
    //     content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //     request.Content = content;
    //     try
    //     {
    //         var response = await client.SendAsync(request);
    //         if (!response.IsSuccessStatusCode)
    //         {
    //             Console.WriteLine(response.ReasonPhrase);
    //         }
    //
    //         Console.WriteLine(await response.Content.ReadAsStringAsync());
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    //
    // }

      [Fact]

        public void DataTest2()
        {
           string expected =  "https://127.0.0.1:30080/api/v1/".TrimEnd(new[] { 'v', '1', '/' });
           Assert.Equal(expected,"https://127.0.0.1:30080/api");
        }

}
