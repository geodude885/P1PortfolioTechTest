using P1Portfolio.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace P1Portfolio.Clients;

public class SecclApiClient
{
    private readonly HttpClient _httpClient;
    private readonly SecclApiSettings _settings;

    public SecclApiClient(HttpClient httpClient, SecclApiSettings settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    //public async Task<SomeResponseType> GetSomeDataAsync()
    //{
    //    var token = await GetAccessTokenAsync();
    //    _secclApiClient._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //    var response = await _secclApiClient.GetDataAsync("some/endpoint");
    //    // Deserialize and return the data
    //}

    public async Task GetAccessTokenAsync()
    {
        var inputDto = new AccessRequestDto()
        {
            firmId = _settings.FirmId,
            id = _settings.UserId,
            password = _settings.Password
        };

        var content = new StringContent(JsonSerializer.Serialize(inputDto), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("/authenticate", content);
        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();

        JsonDocument jsonDoc = JsonDocument.Parse(responseContent);
        string token = jsonDoc.RootElement.GetProperty("data").GetProperty("token").GetString();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    internal class AccessRequestDto
    {
        public string firmId { get; set; }
        public string id { get; set; }
        public string password { get; set; }
    }
}
