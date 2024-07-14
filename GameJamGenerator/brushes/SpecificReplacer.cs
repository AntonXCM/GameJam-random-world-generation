public class SpecificReplacer<T>(T value, T[] valuesToReplace) : SimpleBrush<T>(value)
{
    readonly T[] valuesToReplace = valuesToReplace;

    public override T GetValue(int x, int y, T current) => valuesToReplace.Contains(current) ? base.GetValue(x, y, current) : current;
}