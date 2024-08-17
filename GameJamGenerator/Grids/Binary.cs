public class BinaryGrid : GridBaseS<bool>
{
    public BinaryGrid(int width, int height, bool baseValue) => Construct(width, height, baseValue);
    public BinaryGrid(int width, int height) : this(width, height, false) { }
    public BinaryGrid(bool[,] grid) => Construct(grid);

    protected override string TileToString(bool tile) => tile ? "██" : "[]";
    protected override int ToStringSymbols => (Width * 2 + 3) * Height;

    protected override object Clone(bool[,] grid) => new BinaryGrid(grid);
}