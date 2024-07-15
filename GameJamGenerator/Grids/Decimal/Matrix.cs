using System.Collections;
using System.Text;
public class Matrix : IGrid<int>
{
    private int[,] grid;
    public Matrix(int[,] grid) => ReplaceGrid(grid);
    public Matrix(int width, int height) : this(new int[width, height]) { }
    public Matrix(int width, int height, int baseValue) : this(width, height) => this.Iterate((Vector2Int pos) => { this[pos] = baseValue; return false; });
    public int this[int row, int col]
    {
        get => grid[row, col];
        set => grid[row, col] = value;
    }
    public int this[Vector2Int pos] 
    { 
        get => this[pos.x, pos.y]; 
        set => this[pos.x, pos.y] = value; 
    }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public override string ToString()
    {
        int TileLength = this.GetMaxValue(x => x).ToString().Length;
        int LineLength = Width * (TileLength + 1) + 1;
        StringBuilder picture = new(LineLength * Height * 2);
        for (int j = 0; j < Height; j++)
        {
            for (int i = 0; i < LineLength; i++)
                picture.Append('-');
            picture.Append('\n');
            for (int i = 0; i < Width; i++)
            {
                string element = this[i, j].ToString();
                while (element.Length < TileLength) element += " ";
                picture.Append('|' + element);
            }
            picture.Append('\n');
        }
        return picture.ToString();
    }

    public object Clone() => new Matrix(grid);
    IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    public IEnumerator<int> GetEnumerator() => grid.Cast<int>().GetEnumerator();

    public void ReplaceGrid(int[,] newGrid)
    {
        grid = newGrid ?? throw new ArgumentNullException("Ну давай, тогда, просто удали объект)");
        Width = grid.GetLength(0);
        Height = grid.GetLength(1);
    }
}