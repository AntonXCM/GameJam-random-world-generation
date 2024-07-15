public static partial class CellsFindingAlgorythms
{
    public static Vector2Int GetTilePosition<T>(this IGrid<T> grid, T Tile)
    {
        TilePositionGetter<T> domashniyIsheyka = new(Tile);
        domashniyIsheyka.Generate(ref grid);
        return domashniyIsheyka.tilePosition;
    }
    private class TilePositionGetter<T> :SimpleIteratorGenerationModule<T>
    {
        public Vector2Int tilePosition;
        readonly T tile;

        public TilePositionGetter(T tile)
        {
            actionStopMode = ActionStopMode.StopIterating;
            this.tile = tile;
        }
        public override bool Action(Vector2Int pos)
        {
            if(!iteratingGrid[pos].Equals(tile)) return false;
            tilePosition = pos;
            return true;
        }
    }
}