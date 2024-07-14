public static class GetGridElementByProperty
{
    public static T GetMaxValue<T>(this IGrid<T> grid, Func<T, double> func)
    {
        T result = default;
        double maxT = 0;
        foreach (var item in grid)
        {
            double thisValue = func.Invoke(item);
            if (thisValue > maxT)
            {
                maxT = thisValue;
                result = item;
            }
        }
        return result;
    }
    public static Vector2Int GetTilePosition<T>(this IGrid<T> grid, T Tile)
    {
        TilePositionGetter<T> domashniyIsheyka = new(Tile);
        domashniyIsheyka.Generate(ref grid);
        return domashniyIsheyka.tilePosition;
    }
    private class TilePositionGetter<T> : SimpleIteratorGenerationModule<T>
    {
        public Vector2Int tilePosition;
        T tile;

        public TilePositionGetter(T tile)
        {
            actionStopMode = ActionStopMode.StopIterating;
            this.tile = tile;
        }
        public override bool Action(Vector2Int pos)
        {
            if (!iteratingGrid[pos].Equals(tile)) return false;
            tilePosition = pos;
            return true;
        }
    }
}