public enum Tile
{
    empty = 5, wall = 30, key = 2, door = 10, hp = 3, player = 4, debug = 1
}
public class Grid : GridBaseS<Tile>
{
    public Grid(int width, int height, Tile baseValue) => Construct(width, height, baseValue);
    public Grid(int width, int height) : this(width, height, Tile.empty) {}
    public Grid(Tile[,] grid) => Construct(grid);

    public static readonly Dictionary<Tile, (char, char)> tileSymbols = new([
        new(Tile.empty, (' ', ' ')),
        new(Tile.wall, ('█', '█')),
        new(Tile.key, ('"', '0')),
        new(Tile.door, ('I', 'I')),
        new(Tile.hp, ('▝', '▞')),
        new(Tile.player, ('7', 'Г')),
        new(Tile.debug, ('.', ' '))
        ]);
    protected override string TileToString(Tile tile)
    {
        (char, char) tileSymbol = tileSymbols[tile];
        return tileSymbol.Item1.ToString() + tileSymbol.Item2;
    }
    protected override int ToStringSymbols => (Width * 2 + 3) * Height;

    protected override object Clone(Tile[,] grid) => new Grid(grid);
}