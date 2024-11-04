public static class GridCaster
{
    public static IGrid<ResulT> Cast<T, ResulT>(this IGrid<T> grid,Func<T,ResulT> castFunc,IGrid<ResulT> outGrid)
    {
        grid.IterateParallel(pos => outGrid[pos] = castFunc(grid[pos]));
        return outGrid;
    }
}