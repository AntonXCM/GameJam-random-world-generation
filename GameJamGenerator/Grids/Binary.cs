public class BinaryGrid : GridBaseS<bool>
{
    public BinaryGrid(int width, int height, bool baseValue) => Construct(width, height, baseValue);
    public BinaryGrid(int width, int height) : this(width, height, false) { }
    public BinaryGrid(bool[,] grid) => Construct(grid);
    protected override string TileToString(bool tile) => tile ? "██" : "[_";
    protected override int ToStringSymbols => (Width * 2 + 3) * Height;

    protected override object Clone(bool[,] grid) => new BinaryGrid(grid);
}
public class MaskBinaryGrid : BinaryGrid
{
    public MaskBinaryGrid(int width, int height, bool baseValue) : base(width, height, baseValue) 
        => maskValues = baseValue ? width * height : 0;
    public MaskBinaryGrid(int width, int height) : this(width, height, false)
    { }
    public MaskBinaryGrid(bool[,] grid) : base(grid) 
        => maskValues = this.Count(b => b);
    public int maskValues { get; private set; }
    public override bool this[int row, int col]
    {
        set
        {
            base[row, col] = value;
            maskValues+=value?1:-1;
        }
    }
}