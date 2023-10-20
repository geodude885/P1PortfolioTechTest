namespace P1Portfolio.Pages.Formatters;
public static class PercentageFormatter
{
    public static string ToPercent(decimal amount)
    {
        return string.Format("{0:0.00}%", amount);
    }
}
