public static class Masks
{
    public static T[,] ChopByMask<MaskT,T>(this IGrid<MaskT> mask, IGrid<T> grid, Vector2Int maskOffset, Func<MaskT, bool> maskCheckFunction = null)
    {
        maskCheckFunction ??= b => !default(MaskT).Equals(b);
        T[,] result = new T[grid.Width, grid.Height];
        maskOffset -= mask.Size / 2;

        mask.IterateMask(pos =>
            {   pos += maskOffset;
                if(grid.SizeRect.IsInRect(pos))
                    result[pos.x, pos.y] = grid[pos];
                return false;
            }, maskCheckFunction);
        return result;
    }
    public static T[] GetValues<MaskT,T>(this IGrid<MaskT> mask, IGrid<T> grid, Vector2Int maskOffset, Func<MaskT, bool> maskCheckFunction = null)
    {
        maskCheckFunction ??= b => !default(MaskT).Equals(b);
        List<T> values = new List<T>(mask is MaskBinaryGrid ? (mask as MaskBinaryGrid).maskValues : mask.Count(b=> !default(MaskT).Equals(b)));
        maskOffset -= mask.Size / 2;
        mask.IterateMask(pos => 
        {
            pos += maskOffset;
            if(grid.SizeRect.IsInRect(pos)) values.Add(grid[pos]); 
            return false; 
        }, maskCheckFunction);
        return values.ToArray();
    }

}