using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P1Portfolio.Configuration;
using P1Portfolio.Data.Dto;
using System.Text;

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

    public async Task<PortfolioSummaryResponseDto> GetAllPortfolioSummaries()
    {
        var getPortfolioSummariesEndpoint = $"/portfolio/{_settings.FirmId}";
        var response = await _httpClient.GetAsync(getPortfolioSummariesEndpoint);
        string responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            response.EnsureSuccessStatusCode();
            var portfolios = JsonConvert.DeserializeObject<PortfolioSummaryResponseDto>(responseContent);
            if (portfolios == null) throw new ArgumentNullException(nameof(portfolios));
            return portfolios;
        } 
        catch (Exception e) when (e is JsonException || e is ArgumentNullException)
        {
            throw new JsonException($"Failed to deserialize response from {getPortfolioSummariesEndpoint}, received response: {responseContent}", e);
        }
    }

    public async Task<PortfolioReportResponseDto> GetPortfolioReport(string portfolioId, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var getPortfolioSummariesEndpoint = $"/portfolio/report/{_settings.FirmId}/{portfolioId}";

        if (fromDate != null || toDate != null)
        {
			getPortfolioSummariesEndpoint += $"?fromDate={fromDate?.ToString("yyyy-MM-dd") ?? ""}&toDate={toDate?.ToString("yyyy-MM-dd") ?? ""}";
        }
        var response = await _httpClient.GetAsync(getPortfolioSummariesEndpoint);
        string responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            response.EnsureSuccessStatusCode();
            var portfolioReport = JsonConvert.DeserializeObject<PortfolioReportResponseDto>(responseContent);
            if (portfolioReport == null) throw new ArgumentNullException(nameof(portfolioReport));
            return portfolioReport;
        }
        catch (Exception e) when (e is JsonException || e is ArgumentNullException)
        {
            throw new JsonException($"Failed to deserialize response from {getPortfolioSummariesEndpoint}, received response: {responseContent}", e);
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException($"Received Http Error from {getPortfolioSummariesEndpoint}, received response: {responseContent}", e);
        }
    }

    public async Task AuthenticateAsync()
    {
        var inputDto = new AccessRequestDto()
        {
            firmId = _settings.FirmId,
            id = _settings.UserId,
            password = _settings.Password
        };

        var content = new StringContent(JsonConvert.SerializeObject(inputDto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/authenticate", content);

        response.EnsureSuccessStatusCode();
        string responseContent = await response.Content.ReadAsStringAsync();

        try
        {
            JObject jsonResponse = JObject.Parse(responseContent);
            string token = jsonResponse["data"]["token"].ToString(); 
            
            if (_httpClient.DefaultRequestHeaders.Contains("api-token")) _httpClient.DefaultRequestHeaders.Remove("api-token");
            _httpClient.DefaultRequestHeaders.Add("api-token", token);
            
        } catch (Exception e)
        {
            throw new Exception($"Failed to deserialise and add Seccl api-token. Received response: {responseContent}", e);
        }
    }

    internal class AccessRequestDto
    {
        public string firmId { get; set; }
        public string id { get; set; }
        public string password { get; set; }
    }
}
