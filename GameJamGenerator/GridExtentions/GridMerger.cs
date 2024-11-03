public static class GridMerger
{
    public static ResulT[,] Merge<FacTor,FacTor2,ResulT>(this IGrid<FacTor> factor, IGrid<FacTor2> factor2, Func<FacTor,FacTor2,ResulT> formula)
    {
        if(factor.Size != factor2.Size) throw new ArgumentOutOfRangeException("Сетки надо делать одинаковыми т_т");
        ResulT[,] result = new ResulT[factor.Width,factor.Height];
        factor.Iterate(pos =>
        {
            result[pos.x,pos.y] = formula(factor[pos],factor2[pos]);
            return false;
        });
        return result;
    }
}