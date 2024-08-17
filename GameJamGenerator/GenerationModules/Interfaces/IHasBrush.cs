public interface IHasBrush<T>
{
    IBrush<T> Brush { get; set; }
}
public static class BrushBuilder
{
    public static ClassT Brush<ClassT, T>(this ClassT @class, T tile) where ClassT : IHasBrush<T> => @class.Brush(new SimpleBrush<T>(tile));
    public static ClassT Brush<ClassT,T>(this ClassT @class, IBrush<T> brush) where ClassT : IHasBrush<T>
    {
        @class.Brush = brush;
        return @class;
    }
}