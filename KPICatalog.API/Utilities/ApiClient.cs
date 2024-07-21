using System.Text.Json;
using System.Text;

namespace KPICatalog.API.Utilities;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
    {
        // Сериализация данных запроса в JSON
        var jsonRequest = JsonSerializer.Serialize(requestData);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        // Выполнение POST запроса
        var response = await _httpClient.PostAsync(url, content);

        // Убедитесь, что запрос был успешным
        response.EnsureSuccessStatusCode();

        // Чтение и десериализация ответа
        var jsonResponse = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TResponse>(jsonResponse);
    }
}
