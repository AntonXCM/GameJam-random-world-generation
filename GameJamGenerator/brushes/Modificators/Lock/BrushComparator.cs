public abstract class BrushComparator<T> : IBrush<T>
{
    IBrush<T> originalBrush;

    public BrushComparator(IBrush<T> originalBrush)
    {
        this.originalBrush = originalBrush;
    }
    protected abstract T CompareValues(T orig,T brushOut);
    public T GetValue(int x,int y,T current) => CompareValues(current, originalBrush.GetValue(x,y,current));
}