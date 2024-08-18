public static partial class CellsFindingAlgorythms
{
    public static T GetMaxValue<T>(this IGrid<T> grid, Func<T, double> func)
    {
        T result = default;
        double maxT = 0;
        foreach (var item in grid)
        {
            double thisValue = func.Invoke(item);
            if (thisValue > maxT)
            {
                maxT = thisValue;
                result = item;
            }
        }
        return result;
    }
    public static OuT GetMaxValue<T, OuT>(this IGrid<T> grid, Func<T, (double comparser, OuT result)> func)
    {
        OuT result = default;
        double maxT = 0;
        foreach(var item in grid)
        {
            (double thisValue, OuT _result) = func.Invoke(item);
            if(thisValue > maxT)
            {
                maxT = thisValue;
                result = _result;
            }
        }
        return result;
    }
}