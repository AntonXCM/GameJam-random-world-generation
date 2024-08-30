namespace MathA;

public class PerlinNoise
{
    readonly Vector2 cellSize = new(4, 4);
    VectorGrid noiseMap;

    public PerlinNoise(VectorGrid noiseMap,Vector2 cellSize) : this(noiseMap)
    {
        this.cellSize = cellSize;
    }

    public PerlinNoise(VectorGrid noiseMap) => this.noiseMap = noiseMap;

    public float GetNoise(float x, float y) => GetNoise(new(x, y));
    public float GetNoise(Vector2 pos)
    {
        Vector2 cellPos = (pos % cellSize)/cellSize;
        double[] poses = (from near in new Vector2[] {Vector2Int.Zero,Vector2Int.Down,Vector2Int.Right,Vector2Int.One}
                          select (double)(near-cellPos).DotProduct(noiseMap[(Vector2Int)(pos / cellSize + near)])).ToArray();
        return (float)MathA.Interpolation.Sinus(MathA.Interpolation.Sinus(poses[1],poses[0],cellPos.y),MathA.Interpolation.Sinus(poses[3],poses[2],cellPos.y),cellPos.x);
    }
}