internal class SpecificReplacer<T> : SimpleBrush<T>
{
    T[] valuesToReplace;
    public SpecificReplacer(T value, T[] valuesToReplace) : base(value)
    {
        this.valuesToReplace = valuesToReplace;
    }
    public override T GetValue(int x, int y, T current) => valuesToReplace.Contains(current) ? base.GetValue(x, y, current) : current;
}