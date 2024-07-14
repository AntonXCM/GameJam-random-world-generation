using System.Collections;
using System.Text;

public class Matrix : IGrid<int>
{
    private int[,] grid;
    public Matrix(int[,] grid)
    {
        this.grid = grid;
    }
    public Matrix(int width, int height) : this(new int[width, height]) { }
    public Matrix(int width, int height, int baseValue) : this(width, height)
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                grid[i, j] = baseValue;
    }
    public int this[int row, int col]
    {
        get => grid[row, col]; set
        { grid[row, col] = value; }
    }

    public int Width { get => grid.GetLength(0); }
    public int Height { get => grid.GetLength(1); }
    public override string ToString()
    {
        int TileLength = this.GetMaxValue(x => x).ToString().Length;
        int LineLength = Width * (TileLength + 2) + 1;
        StringBuilder picture = new(LineLength * Height * 2);
        for (int j = 0; j < Height; j++)
        {
            for (int i = 0; i < Width; i++)
            {
                string element = this[i, j].ToString();
                while (element.Length < TileLength) element += " ";
                picture.Append('|' + element + '|');
            }
            picture.Append('\n');
            for (int i = 0; i < LineLength; i++)
                picture.Append('-');
            picture.Append('\n');
        }
        return picture.ToString();
    }

    public object Clone() => new Matrix(grid);
    IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    public IEnumerator<int> GetEnumerator() => grid.Cast<int>().GetEnumerator();
}