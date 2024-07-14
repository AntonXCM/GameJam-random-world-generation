public abstract class CellularMachine<T> : IteratorGenerationModule<T>
{
    protected IGrid<T> inputGrid;
    public void Generate(ref IGrid<T> grid)
    {
        Initialze(ref grid);
        Iterate();
    }

    protected override void Iterate()
    {
        Parallel.For(0, rows, i =>
        {
            Parallel.For(0, cols, j =>
            {
                Action(new(i, j));
            });
        });
    }
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        inputGrid = (IGrid<T>)grid.Clone();
    }
}