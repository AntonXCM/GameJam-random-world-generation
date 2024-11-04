
public class GridSharpener<T> :GridCellsToMatrixMultiplier<T,int>
{
    public GridSharpener(Func<T,int,T> multiplyFunc,Func<T,T,T> sumFunc) : base(new IntMatrix(new int[3,3] { { -1,-1,-1 },{ -1,9,-1},{ -1,-1,-1 } }),multiplyFunc,sumFunc)
    {}
}