using MatBlazor;
using Microsoft.AspNetCore.Components;
using P1Portfolio.Clients;
using P1Portfolio.Data;
using P1Portfolio.Data.Dto;

namespace P1Portfolio.Services;

public class SecclService : ISecclService
{
	protected IMatToaster Toaster { get; set; }
	private readonly SecclApiClient _secclClient;

    public SecclService(IMatToaster toaster, SecclApiClient seeclClient)
    {
        Toaster = toaster;
        _secclClient = seeclClient;
    }

    public async Task<List<PortfolioSummaryViewModel>> GetAllPortfolioSummraiesAsync()
    {
        try {
            await _secclClient.AuthenticateAsync();
            return (await _secclClient.GetAllPortfolioSummaries()).Data
                .Select(PortfolioSummaryViewModel.From)
                .ToList();
	    } catch (Exception ex)
		{
			Toaster.Add("An error occurred while loading Portfolio Summaries", MatToastType.Danger, "");
            // This is where the error logging would go using a logger
            return new List<PortfolioSummaryViewModel>();
		}
    }

    public async Task<List<PortfolioReportDto>> GetPortfolioReports(List<string> portfolioIds, DateTime? fromDate = null, DateTime? toDate = null)
	{
		var reports = new List<PortfolioReportDto>();
		try
		{
            // Note: Seccl API Seems to return 403 if attempting these in parallel
            foreach (var portfolioId in portfolioIds)
            {
                await _secclClient.AuthenticateAsync();
                reports.Add((await _secclClient.GetPortfolioReport(portfolioId, fromDate, toDate)).Data);
            }
	    } catch (Exception ex)
		{
			Toaster.Add("An error occurred while loading Portfolio Reports", MatToastType.Danger, "");
            // This is where the error logging would go using a logger
		}
        return reports;
    }
}
