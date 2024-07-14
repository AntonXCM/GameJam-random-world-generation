using System.Collections.Concurrent;

public class SectorLimitComponent<T> : IteratorGenerationModuleComponent<T>
{
    public enum SortMode
    {
        None, Random, Linear
    }
    Vector2Int sectorSize;
    uint sectorUndoMax, sectorSquare;
    SortMode sortMode;
    public SectorLimitComponent(Vector2Int sectorSize, uint sectorMax = 1, SortMode sortMode = SortMode.Random)
    {
        uint x = (uint)Math.Abs(sectorSize.x), y = (uint)Math.Abs(sectorSize.y);
        sectorSquare = x * y;
        if (sectorMax >= sectorSquare) throw new IndexOutOfRangeException("Максимум сектора больше его площади. Компонент стал бесполезен и в этом виноват ты.");
        if (sectorMax == 0) throw new IndexOutOfRangeException("Максимум сектора равен нулю. Модуль больше не работоспособен");
        this.sectorSize = new((int)x, (int)y);
        sectorUndoMax = sectorSquare - sectorMax;
        this.sortMode = sortMode;
    }
    ConcurrentDictionary<Vector2Int, List<(Vector2Int pos, T lastValue)>> affectedPositionsInSectors = new();
    protected override GenerationModule<T>.OnDrawTileDelegate OnDrawTile => (Vector2Int pos, T value, T lastValue) =>
    {
        List<(Vector2Int pos, T lastValue)> sector = affectedPositionsInSectors.GetOrAdd(pos / sectorSize, []);
        if (!sector.Any(x => x.pos == pos)) sector.Add((pos, lastValue));
    };
    public override IteratorGenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => () =>
        {
            holder.OnDrawTile -= OnDrawTile;
            Parallel.For(0, affectedPositionsInSectors.Count, j =>
            {
                List<(Vector2Int pos, T lastValue)> sector;
                switch (sortMode)
                {
                    default:
                        sector = affectedPositionsInSectors.ElementAt(j).Value;
                        break;
                    case SortMode.Random:
                        sector = affectedPositionsInSectors.ElementAt(j).Value.OrderBy(x => GlobalGenRandom.Next(sectorSquare)).ToList();
                        break;
                    case SortMode.Linear:
                        sector = affectedPositionsInSectors.ElementAt(j).Value.OrderBy(v => v.pos.x + v.pos.y * sectorSize.x).ToList();
                        break;
                }
                Parallel.For(0, Math.Min(sectorUndoMax, sector.Count), I =>
                {
                    int i = (int)I;
                    holder.DrawTile(sector[i].pos, sector[i].lastValue);
                });
            });
        };
}