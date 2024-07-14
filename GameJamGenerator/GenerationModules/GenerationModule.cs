using System.Collections;

public abstract class GenerationModule<T>
{
    protected IteratingGrid iteratingGrid;
    protected class IteratingGrid : IGrid<T>
    {
        private readonly IGrid<T> grid;
        /// <summary>
        /// Я ценю инкапсуляцию, так что, мы можем получить только копию самой сетки. Поплачь об этом >:^)
        /// </summary>
        public IGrid<T> LookAtGrid => (IGrid<T>)grid.Clone();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IteratingGrid(IGrid<T> iteratingGrid, ref OnDrawTileDelegate onDrawTile)
        {
            grid = iteratingGrid;
            Width = grid.Width;
            Height = grid.Height;
            OnDrawTile = onDrawTile;
        }
        public event OnDrawTileDelegate OnDrawTile;
        public void DrawTile(Vector2Int pos, T value)
        {
            T lastValue = grid[pos];
            grid[pos] = value;
            OnDrawTile?.Invoke(pos, value, lastValue);
        }
        public void DrawTile(Vector2Int pos, IBrush<T> brush) => DrawTile(pos, brush.GetValue(pos, grid[pos]));

        public T this[int row, int col] { get => grid[row, col]; set => this[new(row, col)] = value; }
        public T this[Vector2Int pos] { get => grid[pos]; set => DrawTile(pos, value); }

        public object Clone() => new IteratingGrid(grid, ref OnDrawTile);
        public IEnumerator<T> GetEnumerator() => grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    }
    /// <summary>
    /// Я ценю инкапсуляцию, так что, мы можем получить только копию самой сетки. Поплачь об этом >:^)
    /// </summary>
    public IGrid<T> LookAtGrid => iteratingGrid.LookAtGrid;
    protected int Rows { get; private set; }
    protected int Cols { get; private set; }
    public SeparateComponentHolder componentHolder;
    public GenerationModule() => componentHolder = SeparateComponentHolder.GetFromObject(this);
    public virtual void Generate(ref IGrid<T> grid) => Initialze(ref grid);
    protected virtual void Initialze(ref IGrid<T> grid)
    {
        iteratingGrid = new(grid, ref OnDrawTile);
        Rows = grid.Width;
        Cols = grid.Height;
    }
    public void DrawTile(Vector2Int pos, T value) => iteratingGrid.DrawTile(pos, value);
    public delegate void OnDrawTileDelegate(Vector2Int pos, T value, T lastValue);
    public event OnDrawTileDelegate OnDrawTile;
}