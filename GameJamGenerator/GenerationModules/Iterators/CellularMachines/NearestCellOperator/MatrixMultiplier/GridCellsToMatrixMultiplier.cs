public class GridCellsToMatrixMultiplier<T,MaTrix> :NearestCellOperator<T> where MaTrix : notnull
{
    MatrixBase<MaTrix> matrix;
    Func<T,MaTrix, T> MultiplyFunc;
    Func<T,T, T> SumFunc;
    public GridCellsToMatrixMultiplier(MatrixBase<MaTrix> matrix,Func<T,MaTrix,T> multiplyFunc,Func<T,T,T> sumFunc)
    {
        this.matrix = matrix;
        Mask = new(matrix.Width,matrix.Height,true);
        MultiplyFunc = multiplyFunc;
        SumFunc = sumFunc;
    }
    protected override T CalculateValueFromCells(T[,] nearest,T[] nearestValues,Vector2Int pos)
    {
        T cell;
        var multipliedPixels = nearest.ToArrayGrid().Merge(matrix,MultiplyFunc).ToArrayGrid();
        cell = multipliedPixels[0,0];
        multipliedPixels.Iterate(pos =>
        {
            if(pos != Vector2Int.Zero) cell = SumFunc(cell,multipliedPixels[pos]);
            return false;
        });
        return cell;
    }
}