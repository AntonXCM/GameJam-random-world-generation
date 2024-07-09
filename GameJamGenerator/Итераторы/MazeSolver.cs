public abstract class MazeSolver<T> : BucketIterator<T>
{
    readonly protected Vector2Int startPos, endPos;
    readonly Func<T,int> tileWeight;
    Matrix hardnessToGetPoint;
    public MazeSolver(Vector2Int startPos, Vector2Int endPos, Func<T, int> tileWeight) : base([startPos], [])
    {
        this.startPos = startPos;
        this.endPos = endPos;
        this.tileWeight = tileWeight;
    }
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        hardnessToGetPoint = new(grid.Width, grid.Height, int.MaxValue);
        hardnessToGetPoint[startPos.x,startPos.y] = 0;
    }
    public override bool? Action(Vector2Int pos)
    {
        if(pos != startPos)
            hardnessToGetPoint[pos.x,pos.y] = GetThatCellHardness(pos);
        return false;
    }
    protected override void Iterate()
    {
        base.Iterate();
        List<Vector2Int> solution = [endPos];
        for (Vector2Int pos = endPos; pos != startPos;)
        {
            List<(Vector2Int pos, int weight)> potentialPoses = [(new(), int.MaxValue)];
            foreach (Vector2Int position in pos.GetNearFourCells(Vector2Int.Zero, new Vector2Int(iteratingGrid.Width - 1, iteratingGrid.Height - 1)))
                if (hardnessToGetPoint[position.x, position.y] < potentialPoses[0].weight) potentialPoses = [(position, hardnessToGetPoint[position.x, position.y])];
                else if (hardnessToGetPoint[position.x, position.y] == potentialPoses[0].weight) potentialPoses.Add((position, hardnessToGetPoint[position.x, position.y]));
            pos = potentialPoses.OrderBy(x => GlobalGenRandom.Next()).FirstOrDefault().pos;
            solution.Add(pos);
        }
        WorkWithSolution(solution);
    }
    protected abstract void WorkWithSolution(List<Vector2Int> solution);
    private int GetThatCellHardness(Vector2Int pos) => 
        hardnessToGetPoint.GetNearFourCells(pos,999).OrderBy(cell => cell).FirstOrDefault() + tileWeight(iteratingGrid[pos]);
    public override bool CheckPosition(Vector2Int pos) => GetThatCellHardness(pos) < hardnessToGetPoint[pos.x,pos.y]&& !positionsToCheck.Contains(pos);
}