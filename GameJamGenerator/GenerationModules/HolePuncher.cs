public class HolePuncher<T>(T empty, T block, T hole) : CellularMachine<T>
{
    protected T Empty = empty, Block = block, Hole = hole;

    public override bool Action(Vector2Int pos)
    {
        bool success = TryToMakeHole(pos);
        if (success) SuccededToMakeHole?.Invoke(pos.x, pos.y);
        else FailedToMakeHole?.Invoke(pos.x, pos.y);
        return success;
    }
    public event Action<int, int>? SuccededToMakeHole;
    public event Action<int, int>? FailedToMakeHole;
    public virtual bool TryToMakeHole(Vector2Int pos)
    {
        if (!inputGrid[pos].Equals(Block)) return false;
        if (IsCross(inputGrid.GetNearFourCells(pos, Hole)))
        {
            MakeHole(pos);
            return true;
        }
        return false;
        bool IsCross(T[] values) => CheckThatCross(values) || CheckThatCross(values.Reverse().ToArray());
        bool CheckThatCross(T[] values) => !values[0].Equals(Empty) && !values[2].Equals(Empty) && !values[1].Equals(Block) && !values[3].Equals(Block);
    }
    public void MakeHole(Vector2Int pos)
    {
        if (Block.Equals(Hole)) return;
        iteratingGrid.DrawTile(pos, Hole);
    }
}