namespace P1Portfolio.Pages.Formatters;
public static class MoneyFormatter
{
    public static string ToMoney(decimal amount)
    {
        return string.Format("{0:N2} GBP", amount);
    }
}
