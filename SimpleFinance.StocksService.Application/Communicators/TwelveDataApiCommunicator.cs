using Microsoft.Extensions.Configuration;

namespace SimpleFinance.StocksService.Application.Communicators;

public class TwelveDataApiCommunicator : IApiCommunicator
{
    private readonly IConfiguration _configuration;
    private readonly string apiUrl, apiHost, apiKey;

    public TwelveDataApiCommunicator(IConfiguration configuration)
    {
        _configuration = configuration;
        apiUrl = _configuration.GetSection("ApiCommunicator").GetSection("TwelveDataUrl").Value;
        apiHost = _configuration.GetSection("ApiCommunicator").GetSection("TwelveData-X-RapidAPI-Host").Value;
        apiKey = _configuration.GetSection("ApiCommunicator").GetSection("TwelveData-X-RapidAPI-Key").Value;
    }

    public async Task<string> SendGetRequest(string parameters)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(apiUrl + parameters),
            Headers =
            {
                { "X-RapidAPI-Host", apiHost },
                { "X-RapidAPI-Key", apiKey },
            }
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        return body;
    }
}
