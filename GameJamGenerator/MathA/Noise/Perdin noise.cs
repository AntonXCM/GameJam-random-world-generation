namespace MathA;

public class PerlinNoise
{
    readonly Vector2 cellSize = new(4, 4);
    VectorGrid noiseMap;

    public PerlinNoise(VectorGrid noiseMap, Vector2 cellSize) : this(noiseMap) => this.cellSize = cellSize;
    public PerlinNoise(VectorGrid noiseMap) => this.noiseMap = noiseMap;

    public float GetNoise(float x, float y) => GetNoise(new(x, y));
    public float GetNoise(Vector2 pos)
    {
        Vector2Int cellPos = pos % cellSize;
        (Vector2, Vector2)[] vectors = GetVectors(pos);
        return vectors.Select(v=>v.Item1.DotProduct(v.Item2)).Average();
    }
    public (Vector2,Vector2)[] GetVectors(Vector2 pos)
    {
        Vector2Int cell1 = pos / cellSize;
        Vector2Int cell2 = cell1+Vector2Int.One;
        return [GetTuple(cell1), GetTuple(cell2), GetTuple(new(cell1.x, cell2.y)), GetTuple(new(cell2.x, cell1.y))];
        (Vector2, Vector2) GetTuple(Vector2 vector) => (noiseMap[vector], (vector * cellSize-pos)/cellSize);
    }
}