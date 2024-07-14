public class SimpleBrush<T>(T value) : IBrush<T>
{
    protected T Value = value;
    public virtual T GetValue(int x, int y, T current) => Value;
}