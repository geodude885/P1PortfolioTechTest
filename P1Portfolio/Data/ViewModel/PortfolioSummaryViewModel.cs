using P1Portfolio.Data.Dto;

namespace P1Portfolio.Data;

public class PortfolioSummaryViewModel
{
    public bool IsSelected { get; set; }
    public string Id { get; set; }
    public string FirmId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Currency { get; set; }
    public decimal CurrentValue { get; set; }
    public int Accounts { get; set; }
    public decimal UninvestedCash { get; set; }
    public decimal Growth { get; set; }
    public decimal GrowthPercent { get; set; }
    public decimal AdjustedGrowth { get; set; }
    public decimal AdjustedGrowthPercent { get; set; }

    public string GetSelectedClass { get 
        {
            return IsSelected ? "selected" : "";
        } 
    }
    

    public static PortfolioSummaryViewModel From(PortfolioSummaryDto dto)
    {
        return new PortfolioSummaryViewModel
        {
            Id = dto.Id,
            FirmId = dto.FirmId,
            Name = dto.Name,
            Status = dto.Status,
            Currency = dto.Currency,
            CurrentValue = dto.CurrentValue,
            Accounts = dto.Accounts,
            UninvestedCash = dto.UninvestedCash,
            Growth = dto.Growth,
            GrowthPercent = dto.GrowthPercent,
            AdjustedGrowth = dto.AdjustedGrowth,
            AdjustedGrowthPercent = dto.AdjustedGrowthPercent
        };
    }
}

