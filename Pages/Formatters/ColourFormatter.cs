namespace P1Portfolio.Pages.Formatters;
public static class ColourFormatter
{
    public static string GetTextColourClass(decimal amount)
    {
        if (amount < 0) return "red-text";
        return "green-text";
    }

    public static string GetStatusColourClass(string status)
    {
        switch (status.ToLower())
        {
            case "active":
                return "green-text";
            case "pending":
                return "amber-text";
            default:
                return "red-text";
        }
    }
}
