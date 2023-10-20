using P1Portfolio.Data;
using P1Portfolio.Data.Dto;

namespace P1Portfolio.Services;
public interface ISecclService
{
    public Task<List<PortfolioSummaryViewModel>> GetAllPortfolioSummraiesAsync();
    public Task<List<PortfolioReportDto>> GetPortfolioReports(List<string> portfolioIds, DateTime? fromDate = null, DateTime? toDate = null);
}
