using System.Diagnostics;

public class NoiseForest : GameGenerator
{
    public override Grid Generate(int playerX)
    {
        IGrid<Tile> grid = new Grid(9, 9);
        BucketFill<Tile> bucket = new(new List<Vector2Int>() { new(0, 6) }, new(), new NoiseBrush<Tile>([(Tile.door, 1), (Tile.wall, 1)]));
        //bucket.componentHolder.AddComponent(new DebuggerComponent<Tile>());
        bucket.componentHolder.AddComponent((IComponent<IteratorGenerationModule<Tile>>)new StopwatchComponent<Tile>());
        bucket.componentHolder.AddComponent((IComponent<IteratorGenerationModule<Tile>>)new SectorLimitComponent<Tile>(new(3,3),3,SectorLimitComponent<Tile>.SortMode.Random));
        bucket.Generate(ref grid);
        return (Grid)grid;
    }
}