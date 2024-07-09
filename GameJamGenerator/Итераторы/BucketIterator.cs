public abstract class BucketIterator<T> : IteratorGenerationModule<T>
{
    protected List<Vector2Int> checkedPositions;
    protected Queue<Vector2Int> positionsToCheck;
    public BucketIterator(IEnumerable<Vector2Int> positionsToCheck, List<Vector2Int> notAllowedPositions)
    {
        this.positionsToCheck = new(positionsToCheck);
        checkedPositions = notAllowedPositions;
    }

    protected override void Iterate()
    {
        while(positionsToCheck.Count > 0)
        {
            Vector2Int pos = positionsToCheck.Dequeue();
            Action(pos);
            foreach (Vector2Int position in pos.GetNearFourCells(Vector2Int.Zero, new Vector2Int(iteratingGrid.Width, iteratingGrid.Height) - Vector2Int.one))
                AddPositionIf(position);
            checkedPositions.Add(pos);
        }
    }
    public void AddPositionIf(Vector2Int pos)
    {
        if(CheckPosition(pos)) positionsToCheck.Enqueue(pos);
    }
    public virtual bool CheckPosition(Vector2Int pos) => !checkedPositions.Contains(pos)&&!positionsToCheck.Contains(pos);
}
