public class HolePuncher<T> : CellularMachine<T>, IHasBrush<T>
{
    public IBrush<T> Brush { get; set; }
    protected T Empty, Block;

    public HolePuncher(T empty, T block, IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        Empty = empty;
        Block = block;
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
        if(inputGrid[pos].Equals(Block) || !IsCross(inputGrid.GetNearFourCells(pos, default))) return false;
        iteratingGrid.DrawTile(pos, Brush);
        return true;
        bool IsCross(T[] values) => CheckThatCross(values) || CheckThatCross(values.Reverse().ToArray());
        bool CheckThatCross(T[] values) => !values[0].Equals(Empty) && !values[2].Equals(Empty) && !values[1].Equals(Block) && !values[3].Equals(Block);
    }
}