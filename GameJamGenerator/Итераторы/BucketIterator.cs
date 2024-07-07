internal abstract class BucketIterator<T> : IteratorGenerationModule<T>
{
    protected  List<Vector2Int> positionsToCheck,checkedPositions;
    internal BucketIterator(List<Vector2Int> positionsToCheck, List<Vector2Int> notAllowedPositions)
    {
        this.positionsToCheck = positionsToCheck;
        checkedPositions = notAllowedPositions;
    }

    protected override void Iterate()
    {
        while(positionsToCheck.Count > 0)
        {
            Vector2Int pos = positionsToCheck[0];
            Action(pos);
            foreach (Vector2Int position in pos.GetNearFourCells(Vector2Int.Zero, new Vector2Int(iteratingGrid.Width, iteratingGrid.Height) - Vector2Int.one))
                AddPositionIf(position);
            checkedPositions.Add(pos);
            positionsToCheck.RemoveAt(0);
        }
    }
    internal void AddPositionIf(Vector2Int pos)
    {
        if(CheckPosition(pos)) positionsToCheck.Add(pos);
    }
    internal virtual bool CheckPosition(Vector2Int pos) => !checkedPositions.Contains(pos)&&!positionsToCheck.Contains(pos);
}
