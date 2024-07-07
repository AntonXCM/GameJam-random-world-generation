public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(8, 9);
        new BucketFill<Tile>(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.empty, 3), (Tile.wall, 5)])).Generate(ref grid);
        ShowMiddleResult(grid);
        int half = (grid.Height - 1) / 2;
        new PathCutter<Tile>(new(grid.Width - 1, 0), new(0, half), t => (int)t, new SpecificReplacer<Tile>(Tile.debug, [Tile.wall, Tile.empty])).Generate(ref grid);
        new PathCutter<Tile>(new(0, half), new(grid.Width - 1, grid.Height - 1), t => (int)t, new SpecificReplacer<Tile>(Tile.debug, [Tile.wall, Tile.empty])).Generate(ref grid);
        return (Grid)grid;

        static void ShowMiddleResult(IGrid<Tile> grid)
        {
            Console.WriteLine(grid.ToString());
            return;
            Console.ReadKey();
        }
    }
}