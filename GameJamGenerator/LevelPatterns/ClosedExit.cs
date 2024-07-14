public class ClosedExit:GameGenerator
{
    public override Grid Generate(int playerX)
    {
        int WallStart = GlobalGenRandom.Next(2, 5),
            WallCenter = GlobalGenRandom.Next(2, 5);
        IGrid<Tile> grid = new Grid(8, 9);
        grid.DrawLine(Tile.wall, new(0, WallStart), new(7, WallCenter));
        HolePuncher<Tile> puncher = new HolePuncher<Tile>(Tile.empty, Tile.wall, Tile.door);
        puncher.componentHolder.AddComponent((IComponent<IteratorGenerationModule<Tile>>)new SectorLimitComponent<Tile>(new(8, 9)));
        puncher.Generate(ref grid);
        new BucketFill<Tile>(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.empty, 11), (Tile.wall, 1)])).Generate(ref grid);
        new PathCutter<Tile>(grid.GetTilePosition(Tile.door), new(playerX, grid.Height - 1), t => (int)t, new SpecificReplacer<Tile>(Tile.empty, [Tile.wall])).Generate(ref grid);
        grid[playerX, grid.Height - 1] = Tile.player;
        ShowMiddleResult(grid);
        grid.PlaceInRadius(Tile.key, new(4, 6), 2, [Tile.empty]);
        new PathCutter<Tile>(grid.GetTilePosition(Tile.key), new(playerX, grid.Height - 1), t => (int)t, new SpecificReplacer<Tile>(Tile.empty, [Tile.wall])).Generate(ref grid);
        return (Grid)grid;

        static void ShowMiddleResult(IGrid<Tile> grid)
        {
            return;
            Console.WriteLine(grid.ToString());
            Console.ReadKey();
        }
    }
}