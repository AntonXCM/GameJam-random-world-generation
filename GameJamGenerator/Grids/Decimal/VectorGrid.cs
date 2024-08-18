﻿public class VectorGrid:GridBaseS<Vector2>
{
    public VectorGrid(int width, int height, Vector2 baseValue) => Construct(width, height, baseValue);
    public VectorGrid(int width, int height) : this(width, height, Vector2Int.Zero) { }
    public VectorGrid(int width, int height, int randomScale) 
    {
        Vector2[,] grid = new Vector2[width, height];
        new RectInt(width, height).Iterate(pos =>
        {
            grid[pos.x, pos.y] = Vector2.Random * randomScale;
            return false;
        });
        Construct(grid);
    }
    public VectorGrid(Vector2[,] grid) => Construct(grid);

    protected override string TileToString(Vector2 tile) => tile.ToSymbol()+"|";
    protected override int ToStringSymbols => Width*2;

    protected override object Clone(Vector2[,] grid) => new VectorGrid(grid);
}