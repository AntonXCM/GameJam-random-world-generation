public struct RectInt
{
    public Vector2Int Min, Max;
    public RectInt(int x, int y) { Min = Vector2Int.Zero; Max = new(x,y); }
    public RectInt(params Vector2Int[] points)
    {
        IEnumerable<int>xs = points.Select(p => p.x),
                        ys = points.Select(p => p.y);
        initMinMax(new(xs.Min(),ys.Min()),new(xs.Max(),ys.Max()));
    }
    public RectInt initMinMax(Vector2Int min, Vector2Int max)
    {
        Max = max;
        Min = min;
        return this;
    }
    public bool IsInRect(Vector2 point) => MathA.Checks.IsInBounds(point.x, Min.x, Max.x - 1) && MathA.Checks.IsInBounds(point.y, Min.y, Max.y - 1);
    public static RectInt operator &(RectInt a, RectInt b) => a.initMinMax(
        new(Math.Max(a.Min.x, b.Min.x), Math.Max(a.Min.y, b.Min.y)), 
        new(Math.Min(a.Max.x, b.Max.x), Math.Min(a.Max.y, b.Max.y)));
}