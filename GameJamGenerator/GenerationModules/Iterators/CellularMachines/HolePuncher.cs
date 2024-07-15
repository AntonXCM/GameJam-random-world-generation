public class HolePuncher<T> : CellularMachine<T>
{
    protected T Empty, Block, Hole;

    public HolePuncher(T empty, T block, T hole, IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        Empty = empty;
        Block = block;
        Hole = hole;
    }

    public override bool Action(Vector2Int pos)
    {
        bool success = TryToMakeHole(pos);
        if (success) SuccededToMakeHole?.Invoke(pos.x, pos.y);
        else FailedToMakeHole?.Invoke(pos.x, pos.y);
        return success;
    }
    public event Action<int, int>? SuccededToMakeHole, FailedToMakeHole;
    public virtual bool TryToMakeHole(Vector2Int pos)
    {
        if(inputGrid[pos].Equals(Block) || !IsCross(inputGrid.GetNearFourCells(pos, Hole))) return false;
        MakeHole(pos);
        return true;
        bool IsCross(T[] values) => CheckThatCross(values) || CheckThatCross(values.Reverse().ToArray());
        bool CheckThatCross(T[] values) => !values[0].Equals(Empty) && !values[2].Equals(Empty) && !values[1].Equals(Block) && !values[3].Equals(Block);
    }
    public void MakeHole(Vector2Int pos)
    {
        if (Block.Equals(Hole)) return;
        iteratingGrid.DrawTile(pos, Hole);
    }
}