public abstract class IteratorGenerationModule<T> : iGenerationModule<T>
{
    public virtual void Generate(ref IGrid<T> grid)
    {
        Initialze(ref grid);
        Iterate();
    }
    protected virtual void Initialze(ref IGrid<T> grid)
    {
        iteratingGrid = grid;
        rows = iteratingGrid.Width;
        cols = iteratingGrid.Height;
    }
    protected abstract void Iterate();
    internal abstract bool? Action(Vector2Int pos);
    protected IGrid<T> iteratingGrid;
    protected int rows, cols;
}