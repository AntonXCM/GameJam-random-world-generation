public abstract class GenerationModule<T>
{
    protected IGrid<T> iteratingGrid;
    protected int rows, cols;
    public virtual void Generate(ref IGrid<T> grid) => Initialze(ref grid);
    protected virtual void Initialze(ref IGrid<T> grid)
    {
        iteratingGrid = grid;
        rows = iteratingGrid.Width;
        cols = iteratingGrid.Height;
    }
    public event Action<Vector2Int, T, T> OnDrawPixel;
    protected abstract void DrawPixel(Vector2Int pos, T value);
}