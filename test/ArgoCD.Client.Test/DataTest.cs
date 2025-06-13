using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArgoCD.Client.Test;

public class DataTest
{
    [Fact]

    public async Task DataTest1()
    {
        var handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
        };
        var client = new HttpClient(handler);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:8890/api/v1/session");
        request.Headers.Add("Accept", "application/json");
        var content = new StringContent("{\r\n    \"username\":\"admin\",\r\n    \"password\":\"D6KU8lmTC60-O9dw\"\r\n}", null, "application/json");
        request.Content = content;
        try
        {
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ReasonPhrase);
            }
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}
