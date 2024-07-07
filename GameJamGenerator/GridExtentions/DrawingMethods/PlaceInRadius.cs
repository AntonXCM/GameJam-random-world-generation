internal static partial class GridDrawingMethods
{
    public static void PlaceInRadius<T>(this IGrid<T> grid, T value, Vector2Int center, int range, T[] availableTiles)
    {
        Vector2 pos;
        do
        {
            Vector2 random = Vector2.random;
            random.Magnitude = range;
            pos = random + (Vector2)center;
        } while (pos.x < 0 || Math.Round( pos.x) >= grid.Width || pos.y < 0 || Math.Round(pos.y) >= grid.Height || !IsReachable(pos) || !availableTiles.Contains(grid[pos]));

        grid[pos] = value;
        bool IsReachable(Vector2 pos)
        {
            Vector2 direction = (Vector2)center - pos;
            int distance = (int)Math.Max(Math.Abs(direction.x), Math.Abs(direction.y));
            direction.NormalizeMin1();
            for (int i = 0; i <= distance; i++)
            {
                Vector2Int currentCell = new(pos + direction * i);
                if (!availableTiles.Contains(grid[currentCell])) return false;
            }
            return true;
        }
    }
}