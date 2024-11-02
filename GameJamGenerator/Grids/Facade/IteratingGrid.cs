using System.Collections;

public abstract partial class GenerationModule<T>
{
    protected class IteratingGrid :IGrid<T>
    {
        private readonly IGrid<T> grid;
        /// <summary>
        /// Я ценю инкапсуляцию, так что, мы можем получить только копию самой сетки. Поплачь об этом >:^)
        /// </summary>
        public IGrid<T> LookAtGrid => (IGrid<T>)grid.Clone();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2Int Size { get => new(Width, Height); }
        public RectInt SizeRect { get => new(Size, Vector2Int.Zero); }
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
            GridDrawingMethods.DrawTile(grid,pos,value);
            OnDrawTile?.Invoke(pos, value, lastValue);
        }
        public void DrawTile(Vector2Int pos, IBrush<T> brush) => DrawTile(pos, brush.GetValue(pos, grid[pos]));

        public T this[int row, int col] { get => grid[row, col]; set => this[new(row, col)] = value; }
        public T this[Vector2Int pos] { get => grid[pos]; set => DrawTile(pos, value); }

        public object Clone() => new IteratingGrid(grid, ref OnDrawTile);
        public IEnumerator<T> GetEnumerator() => grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
        public void ReplaceGrid(T[,] newGrid) => grid.ReplaceGrid(newGrid);
        public override string ToString() => grid.ToString();

    }
}