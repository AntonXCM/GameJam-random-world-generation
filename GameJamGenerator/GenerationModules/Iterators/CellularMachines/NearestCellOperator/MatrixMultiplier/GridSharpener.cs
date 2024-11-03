
public class GridSharpener<T> :GridCellsToMatrixMultiplier<T,int>
{
    public GridSharpener(Func<T,int,T> multiplyFunc,Func<T,T,T> sumFunc) : base(new IntMatrix(new int[3,3] { { 0 ,-1, 0 },{ -1,5,-1},{0,-1,0 } }),multiplyFunc,sumFunc)
    {}
}