public class HolePuncher<T> : CellularMachine<T>
{
    protected T Empty, Block, Hole;

    public HolePuncher(T empty, T block, T hole)
    {
        Empty = empty;
        Block = block;
        Hole = hole;
    }
    public override bool? Action(Vector2Int pos)
    {
        bool success = TryToMakeHole(pos.x, pos.y);
        if (success) SuccededToMakeHole?.Invoke(pos.x, pos.y);
        else FailedToMakeHole?.Invoke(pos.x, pos.y);
        return success;
    }
    public event Action<int, int> SuccededToMakeHole;
    public event Action<int, int> FailedToMakeHole;
    public virtual bool TryToMakeHole(int x, int y)
    {
        if (!inputGrid[x, y].Equals(Block)) return false;
        if (IsCross(inputGrid.GetNearFourCells(new(x, y), Hole)))
        {
            MakeHole(x, y);
            return true;
        }
        return false;
        bool IsCross(T[] values) => CheckThatCross(values) || CheckThatCross(values.Reverse().ToArray());
        bool CheckThatCross(T[] values) => !values[0].Equals(Empty) && !values[2].Equals(Empty) && !values[1].Equals(Block) && !values[3].Equals(Block);
    }
    public void MakeHole(int x, int y)
    {
        if (Block.Equals(Hole)) return;
        iteratingGrid[x, y] = Hole;
    }
}