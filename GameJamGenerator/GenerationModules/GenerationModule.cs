using System.Collections;

public abstract class GenerationModule<T>
{
    protected IteratingGrid iteratingGrid;
    protected int rows { get; private set; }
    protected int cols { get; private set; }
    public virtual void Generate(ref IGrid<T> grid) => Initialze(ref grid);
    protected virtual void Initialze(ref IGrid<T> grid)
    {
        iteratingGrid = new(grid, OnDrawTile);
        rows = grid.Width;
        cols = grid.Height;
    }
    public delegate void OnDrawTileDelegate(Vector2Int pos, T value, T lastValue);
    public event OnDrawTileDelegate OnDrawTile;
    
    protected class IteratingGrid : IGrid<T>
    {
        private IGrid<T> grid;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IteratingGrid(IGrid<T> iteratingGrid, OnDrawTileDelegate onDrawTile)
        {
            grid = iteratingGrid;
            Width = grid.Width;
            Height = grid.Height;
        }
        public event OnDrawTileDelegate OnDrawTile;
        public void DrawTile(Vector2Int pos, T value)
        {
            T lastValue = grid[pos];
            grid[pos] = value;
            OnDrawTile?.Invoke(pos, value, lastValue);
        }
        public void DrawTile(Vector2Int pos, IBrush<T> brush) => DrawTile(pos, brush.GetValue(pos, grid[pos]));

        public T this[int row, int col] { get => grid[row,col]; set => this[new(row,col)] = value; }
        public T this[Vector2Int pos] { get => grid[pos]; set => DrawTile(pos, value); }

        public object Clone() => new IteratingGrid(grid, OnDrawTile);
        public IEnumerator<T> GetEnumerator() => grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    }
}