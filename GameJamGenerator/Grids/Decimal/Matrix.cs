using System.Text;

public class Matrix : GridBase<int>
{
    public Matrix(int width, int height, int baseValue) => Construct(width, height, baseValue);
    public Matrix(int width, int height) : this(width, height, 0) { }
    public Matrix(int[,] grid) => Construct(grid);

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

    protected override object Clone(int[,] grid) => new Matrix(grid);
}