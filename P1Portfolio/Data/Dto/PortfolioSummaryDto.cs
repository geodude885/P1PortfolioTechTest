namespace P1Portfolio.Data.Dto;
public class PortfolioSummaryResponseDto
{
    public List<PortfolioSummaryDto> Data { get; set; }
    public PortfolioSummaryResponseMetaDto Meta { get; set; }
}

public class PortfolioSummaryResponseMetaDto
{
    public int Count { get; set; }
}

public class PortfolioSummaryDto
{
    public string Id { get; set; }
    public string FirmId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public List<string> NodeId { get; set; }
    public List<string> NodeName { get; set; }
    public string Currency { get; set; }
    public decimal CurrentValue { get; set; }
    public int Accounts { get; set; }
    public decimal UninvestedCash { get; set; }
    public decimal Growth { get; set; }
    public decimal GrowthPercent { get; set; }
    public decimal AdjustedGrowth { get; set; }
    public decimal AdjustedGrowthPercent { get; set; }
}
