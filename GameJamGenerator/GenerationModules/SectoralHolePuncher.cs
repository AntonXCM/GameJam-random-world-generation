using System.Collections.Concurrent;

public class SectoralHolePuncher<T> : HolePuncher<T>
{
    Vector2Int sectorSize;
    public SectoralHolePuncher(Vector2Int sectorSize,T empty, T block, T hole) : base(empty, block, hole)
    { 
        this.sectorSize = sectorSize;
        SuccededToMakeHole += AddToDictionary;
        
    }
    private void AddToDictionary(int x, int y)
    {
        Vector2Int pos = new(x, y);
        succesPositionsInSectors.GetOrAdd(pos / sectorSize, new List<Vector2Int>()).Add(pos);
    }
    ConcurrentDictionary<Vector2Int, List<Vector2Int>> succesPositionsInSectors;
    protected override void Iterate()
    {
        T actualHole = Hole;
        Hole = Block;
        base.Iterate();
        Hole = actualHole;
        foreach (var listVector2 in succesPositionsInSectors)
            MakeHole(listVector2.Value.OrderBy(x => GlobalGenRandom.Next(33)).ToArray()[0]);
    }
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        succesPositionsInSectors = new();
    }
}