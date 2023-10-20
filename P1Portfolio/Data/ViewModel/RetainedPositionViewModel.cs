using P1Portfolio.Data.Dto;

namespace P1Portfolio.Data.ViewModel;
public class RetainedPositionViewModel
{
    public string Isin { get; set; }
    public string AssetName { get; set; }
    public decimal Quantity { get; set; }
    public decimal Value { get; set; }
    public decimal ValueChange { get; set; }
    public decimal? GrowthPercent { get; set; }
    public decimal PercentageByQuantity { get; set; }
    public decimal PercentageByValue { get; set; }

    public static List<RetainedPositionViewModel> AggregateRetainedPositions(IEnumerable<RetainedPosition> retainedPositions)
    {
        var aggregatedPositions = retainedPositions
            .GroupBy(rp => new { rp.Isin, rp.AssetName })
            // Intermediate select to avoid recalculating aggregates
            .Select(g => new
                {

                    QuantityAggregate = g.Sum(rp => rp.Quantity),
                    ValueAggregate = g.Sum(rp => rp.CurrentValue),
                    BookValueAggregate = g.Sum(rp => rp.BookValue),
                    Position = g
                }
            )
            .Select(g => new RetainedPositionViewModel
            {
                Isin = g.Position.Key.Isin,
                AssetName = g.Position.Key.AssetName,
                Quantity = g.QuantityAggregate,
                Value = g.ValueAggregate,
                ValueChange = g.ValueAggregate - g.BookValueAggregate,
                GrowthPercent = g.BookValueAggregate != 0 ? (g.ValueAggregate - g.BookValueAggregate) / g.BookValueAggregate : 0
            })
            .ToList();

        decimal totalQuantity = aggregatedPositions.Sum(ap => ap.Quantity);
        decimal totalValue = aggregatedPositions.Sum(ap => ap.Value);


        foreach (var position in aggregatedPositions)
        {
            if (totalQuantity != 0) position.PercentageByQuantity = (position.Quantity / totalQuantity) * 100M;
			if (totalValue != 0) position.PercentageByValue = (position.Value / totalValue) * 100M;
        }

        return aggregatedPositions;
    }
}
