using P1Portfolio.Clients;
using P1Portfolio.Configuration;
using System.Net.Http.Headers;

namespace P1Portfolio.Services;

public class SecclService : ISecclService
{
    private readonly SecclApiClient _secclClient;
    private readonly SecclApiSettings _settings;

    public SecclService(SecclApiClient seeclClient, SecclApiSettings settings)
    {
        _secclClient = seeclClient;
        _settings = settings;

    }

    public async Task<bool> GetSomeDataAsync()
    {
        try
        {
            await _secclClient.GetAccessTokenAsync();
        } catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}
