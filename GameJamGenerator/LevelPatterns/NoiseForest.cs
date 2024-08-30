public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(9, 9);
        new BucketFill<Tile>(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.wall, 1), (Tile.empty, 7)]))
            .AddComponents<GenerationModule<Tile>, GenerationModuleComponent<Tile>>(new ResultPrintComponent<Tile>(500))
            .Generate(ref grid);
        new MakeLinesFromTiles<Tile>(Direction.Down, Tile.wall).Brush(Tile.player)
            .AddComponents<GenerationModule<Tile>, GenerationModuleComponent<Tile>>(new ResultPrintComponent<Tile>(200))
            .Generate(ref grid);
        new MakeLinesFromTiles<Tile>(Direction.Right, Tile.wall).Brush(Tile.hp)
            .AddComponents<GenerationModule<Tile>, GenerationModuleComponent<Tile>>(new ResultPrintComponent<Tile>(200))
            .Generate(ref grid);
        new MakeLinesFromTiles<Tile>(Direction.Up, Tile.wall).Brush(Tile.debug)
            .AddComponents<GenerationModule<Tile>, GenerationModuleComponent<Tile>>(new ResultPrintComponent<Tile>(200))
            .Generate(ref grid);
        new MakeLinesFromTiles<Tile>(Direction.Left, Tile.wall).Brush(Tile.door)
            .AddComponents<GenerationModule<Tile>, GenerationModuleComponent<Tile>>(new ResultPrintComponent<Tile>(1000))
            .Generate(ref grid);
        new SmoothTerrain<Tile>(tiles => MathA.Averange.Average(tiles.ToArray())).AddComponents<GenerationModule<Tile>,GenerationModuleComponent<Tile>>(new DebuggerComponent<Tile>()).Generate(ref grid);
        return (Grid)grid;
    }
}