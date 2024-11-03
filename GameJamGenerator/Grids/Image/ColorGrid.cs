using Colors;

using System.Collections;
public class ColorGrid :GridBase<Color>
{
    public ColorGrid(Vector2Int size) : this(size.x,size.y){}
    public ColorGrid(int width,int height) : this(new Color[width,height]){}

    public ColorGrid(Color[,] initialGrid) => ReplaceGrid(initialGrid);

    public static ColorGrid FromBitmapGrid(BitmapGrid bitmapGrid)
    {
        var arrayGrid = new ColorGrid(((IGrid)bitmapGrid).Size);
        arrayGrid.Iterate(pos => { arrayGrid[pos] = ((IGrid<System.Drawing.Color>)bitmapGrid)[pos]; return false; });
        return arrayGrid;
    }
    public static BitmapGrid ToBitmapGrid(ColorGrid colorGrid)
    {
        IGrid<System.Drawing.Color> bitmap = new BitmapGrid(((IGrid)colorGrid).Size);
        bitmap.Iterate(pos => { bitmap[pos] = colorGrid[pos]; return false; });
        return (BitmapGrid)bitmap;
    }
    protected override object Clone(Color[,] grid)=> new ColorGrid(grid);

}