using System.Drawing;

public class PerlinNoiseLevel :GameGenerator
{
    public override IGrid Generate(int playerX)
    {
        IGrid<Color> grid = new BitmapGrid(111, 111);
        IGrid<int> matrix = new Matrix(20, 20);
        new BucketFill<Color>([Vector2Int.Zero], [], new PerlinNoiseBrush<Color>(new(50,50,1), new(11,11), 
            f => Color.FromArgb((int)(f*255),0,(int)Math.Abs(100-f * 200)))).Generate(ref grid);
        new BucketFill<int>([Vector2Int.Zero], [], new PerlinNoiseBrush<int>(new(50, 50, 1), new(8,8), f =>
        {
            return (int)(f * 100);
            }))
            .Component(new ResultPrintComponent<int>())
            .Generate(ref matrix);
        return grid;
    }
}