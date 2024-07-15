﻿using System.Collections;
using System.Text;
public enum Tile
{
    empty = 5, wall = 30, key = 2, door = 10, hp = 3, player = 4, debug = 1
}
public class Grid : IGrid<Tile>
{
    private Tile[,] grid;
    public Grid(Tile[,] grid) => ReplaceGrid(grid);

    public Grid(int width, int height) : this(width, height, Tile.empty) { }
    public Grid(int width, int height, Tile baseValue) : this(new Tile[width, height])
    {
        this.Iterate((pos) => { (this as IGrid<Tile>)[pos] = baseValue; return false; });
    }
    public Tile this[int row, int col] { get => grid[row, col]; set => grid[row, col] = value; }

    public int Width { get; private set; }
    public int Height { get; private set; }

    public static readonly Dictionary<Tile, (char, char)> tileSymbols = new([
        new(Tile.empty, (' ', ' ')),
        new(Tile.wall, ('█', '█')),
        new(Tile.key, ('"', '0')),
        new(Tile.door, ('I', 'I')),
        new(Tile.hp, ('▝', '▞')),
        new(Tile.player, ('7', 'Г')),
        new(Tile.debug, ('.', ' '))
        ]);
    public override string ToString()
    {
        StringBuilder picture = new((Width + 1) * Height);
        for (int j = 0; j < Height; j++)
        {
            for (int i = 0; i < Width; i++)
                picture.Append(tileSymbols[this[i, j]].Item1.ToString() + tileSymbols[this[i, j]].Item2);
            picture.Append('\n');
        }
        return picture.ToString();
    }
    public void ReplaceGrid(Tile[,] newGrid)
    {
        grid = newGrid ?? throw new ArgumentNullException("Ну давай, тогда, просто удали объект)");
        Width = grid.GetLength(0);
        Height = grid.GetLength(1);
    }
    public object Clone() => new Grid(grid);
    IEnumerator IEnumerable.GetEnumerator() => grid.GetEnumerator();
    public IEnumerator<Tile> GetEnumerator() => grid.Cast<Tile>().GetEnumerator();
}