using System.Collections;
using System.Diagnostics;
using System.Drawing;

public class BitmapGrid :IGrid<Color>, IDisposable
{
    private Bitmap bitmap;
    private readonly object bitmapLock = new object();

    public BitmapGrid(int width,int height)
    {
        bitmap = new Bitmap(width,height);
    }
    public BitmapGrid(Bitmap bitmap)
    {
        this.bitmap = bitmap;
    }

    public int Width
    {
        get
        {
            lock(bitmapLock)
            {
                return bitmap.Width;
            }
        }
    }

    public int Height
    {
        get
        {
            lock(bitmapLock)
            {
                return bitmap.Height;
            }
        }
    }

    public Color this[int row,int col]
    {
        get
        {
            lock(bitmapLock)
            {
                return bitmap.GetPixel(row,col);
            }
        }

        set
        {
            lock(bitmapLock)
            {
                bitmap.SetPixel(row,col,value);
            }
        }
    }
    public void ReplaceGrid(Color[,] newGrid)
    {
        if(newGrid.GetLength(0) != Width || newGrid.GetLength(1) != Height)
            bitmap = new Bitmap(newGrid.GetLength(0),newGrid.GetLength(1));

        this.Iterate(pos => { ((IGrid<Color>)this)[pos] = newGrid[pos.x,pos.y]; return false; });
    }

    public object Clone() => new BitmapGrid(bitmap);

    public IEnumerator<Color> GetEnumerator()
    {
        for(int row = 0; row < Width; row++)
            for(int col = 0; col < Height; col++)
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
