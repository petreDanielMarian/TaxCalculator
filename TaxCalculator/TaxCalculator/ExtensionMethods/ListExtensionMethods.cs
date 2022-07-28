namespace TaxCalculator.ExtensionMethods;

public static class ListExtensionMethods
{
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null! || list.Count == 0;
    }
}