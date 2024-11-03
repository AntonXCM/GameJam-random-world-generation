public class ArrayGrid<T> :GridBase<T>
{
    public ArrayGrid(T[,] grid) => this.ReplaceGrid(grid);
    protected override object Clone(T[,] grid) => new ArrayGrid<T>(grid);
}
public static class ToArrayGridConverter
{
    public static ArrayGrid<T> ToArrayGrid<T>(this T[,] grid) => new ArrayGrid<T>(grid);
}