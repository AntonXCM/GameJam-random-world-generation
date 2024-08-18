namespace MathA;
public static class Averange
{
    public static int Average(params int[] values) => (int)values.Average();

    public static float Average(params float[] values) => values.Average();

    public static double Average(params double[] values) => values.Average();

    public static string Average(params string[] values)
    {
        if(values == null || values.Length == 0)
            return "";
        return new string(values.Select(s => s.ToCharArray()).Aggregate((acc, next) => acc.Intersect(next).ToArray()));
    }

    public static T Average<T>(params T[] values)
    {
        int maxFreqency = 0;
        List<object> mostFrequent = [];
        foreach(var group in values.GroupBy(v => v))
        {
            int count = group.Count();
            if(count == maxFreqency) mostFrequent.Add(group.Key);
            else if(count > maxFreqency)
            {
                maxFreqency = count;
                mostFrequent = [group.Key];
            }
        }
        return (T)mostFrequent.Order().First();
    }
}