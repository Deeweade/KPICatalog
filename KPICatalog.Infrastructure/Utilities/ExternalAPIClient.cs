using System.Text.Json;
using System.Text;

namespace KPICatalog.Infrastructure.Utilities;

public class ExternalAPIClient
{
    private readonly HttpClient _httpClient;

    public ExternalAPIClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
    {
        var jsonRequest = JsonSerializer.Serialize(requestData);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(jsonResponse);
    }
}
