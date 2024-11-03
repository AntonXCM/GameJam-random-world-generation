using System.Text;

public class IntMatrix : MatrixBase<int>
{
    public IntMatrix(int width, int height, int baseValue) => Construct(width, height, baseValue);
    public IntMatrix(int width, int height) : this(width, height, 0) { }
    public IntMatrix(int[,] grid) => Construct(grid);

    protected override object Clone(int[,] grid) => new IntMatrix(grid);
    protected override double ToNumber(int value) => value;
}
public class FloatMatrix :MatrixBase<float>
{
    public FloatMatrix(int width,int height,float baseValue) => Construct(width,height,baseValue);
    public FloatMatrix(int width,int height) : this(width,height,0) { }
    public FloatMatrix(float[,] grid) => Construct(grid);

    protected override object Clone(float[,] grid) => new FloatMatrix(grid);
    protected override double ToNumber(float value) => value;
}