public abstract class MazeSolver<T> : BucketIterator<T>
{
    readonly protected Vector2Int startPos, endPos;
    private readonly Func<T, int> tileWeight;
    Matrix hardnessToGetPoint;

    public MazeSolver(Vector2Int startPos, Vector2Int endPos, Func<T, int> tileWeight, IComponent<GenerationModule<T>>[] components = null) : base([startPos], [],components)
    {
        this.tileWeight = tileWeight;
        this.startPos = startPos;
        this.endPos = endPos;
    }
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        hardnessToGetPoint = new(grid.Width, grid.Height, int.MaxValue);
        hardnessToGetPoint[startPos] = 0;
    }
    public override bool Action(Vector2Int pos)
    {
        if (pos != startPos)
            hardnessToGetPoint[pos] = GetThatCellHardness(pos);
        return false;
    }
    protected override void Iterate()
    {
        base.Iterate();
        List<Vector2Int> solution = [endPos];
        for (Vector2Int pos = endPos; pos != startPos;)
        {
            int weight = int.MaxValue;
            List<Vector2Int> potentialPoses = [Vector2Int.Zero];
            foreach (Vector2Int position in pos.GetNearFourCells(Vector2Int.Zero, new Vector2Int(iteratingGrid.Width - 1, iteratingGrid.Height - 1)))
            {
                int hardness = hardnessToGetPoint[position];
                if(hardness < weight)
                {
                    potentialPoses = [position];
                    weight = hardness;
                }
                else if(hardness == weight) potentialPoses.Add(position);
            }
            pos = potentialPoses.OrderBy(x => GlobalGenRandom.Next()).FirstOrDefault();
            solution.Add(pos);
        }
        WorkWithSolution(solution);
    }
    protected abstract void WorkWithSolution(List<Vector2Int> solution);
    private int GetThatCellHardness(Vector2Int pos) => hardnessToGetPoint.GetNearFourCells(pos, 999).OrderBy(cell => cell).FirstOrDefault() + tileWeight(iteratingGrid[pos]);
    public override bool CheckPosition(Vector2Int pos) => GetThatCellHardness(pos) < hardnessToGetPoint[pos] && !positionsToCheck.Contains(pos);
}