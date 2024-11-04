using System.Collections;
using System.Text;

public abstract class GridBase<T> : IGrid<T>
{
    public void Construct(int width, int height, T baseValue)
    {
        Construct(new T[width, height]);
        this.Iterate((pos) => { (this as IGrid<T>)[pos] = baseValue; return false; });
    }
    public void Construct(T[,] grid) => ReplaceGrid(grid);

    protected T[,] grid { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public virtual T this[int row, int col] { get => grid[row, col]; set => grid[row, col] = value; }
    public T this[Vector2Int pos] { get => this[pos.x, pos.y]; set => this[pos.x, pos.y] = value; }
    public void ReplaceGrid(T[,] newGrid)
    {
        grid = newGrid ?? throw new ArgumentNullException("Ну давай, тогда, просто удали объект)");
        Width = grid.GetLength(0); Height = grid.GetLength(1);
    }

    IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    public IEnumerator<T> GetEnumerator() => grid.Cast<T>().GetEnumerator();
    
    public object Clone() => Clone((T[,])grid.Clone());
    protected abstract object Clone(T[,] grid);
}

public abstract class GridBaseS<T> :GridBase<T>
{
    public override string ToString()
    {
        StringBuilder picture = new(ToStringSymbols);
        for(int j = 0; j < Height; j++)
        {
            for(int i = 0; i < Width; i++)
                picture.Append(TileToString(this[i, j]));
            picture.Append('\n');
        }
        return picture.ToString();
    }

    protected abstract string TileToString(T tile);
    protected abstract int ToStringSymbols { get; }
}