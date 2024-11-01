using System.Collections;
using System.Diagnostics;
using System.Drawing;

public class BitmapGrid :IGrid<Color>, IDisposable
{
    private readonly Bitmap bitmap;

    public BitmapGrid(int width,int height)
    {
        bitmap = new Bitmap(width,height);
    }

    public int Width => bitmap.Width;
    public int Height => bitmap.Height;

    public Color this[int row,int col]
    {
        get => bitmap.GetPixel(col,row);
        set => bitmap.SetPixel(col,row,value);
    }
    public void ReplaceGrid(Color[,] newGrid)
    {
        if(newGrid.GetLength(0) != Height || newGrid.GetLength(1) != Width)
            throw new ArgumentException("New grid dimensions must match the bitmap dimensions.");

        this.Iterate(pos => { ((IGrid<Color>)this)[pos] = newGrid[pos.x,pos.y]; return false; });
    }

    public Vector2Int Size => new Vector2Int(Width,Height);
    public RectInt SizeRect => new RectInt(Size,Vector2Int.Zero);

    public object Clone() => new BitmapGrid(Width,Height);

    public IEnumerator<Color> GetEnumerator()
    {
        for(int row = 0; row < Height; row++)
            for(int col = 0; col < Width; col++)
                yield return this[row,col];
    }
    public override string ToString()
    {
        using(MemoryStream memoryStream = new MemoryStream())
        {
            bitmap.Save(memoryStream,System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Seek(0,SeekOrigin.Begin);
            string tempFilePath = Path.GetTempFileName() + "randomWorldGeneration.png";
            using(FileStream fileStream = new FileStream(tempFilePath,FileMode.Create,FileAccess.Write))
                memoryStream.CopyTo(fileStream);
            Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
        }

        return "Opened in default App ;)";
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Dispose() => bitmap.Dispose();
}
