
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
    public async Task<(Vector2, Vector2)[]> GetGradientVectorsAsync(Vector2 pos)
    {
        return await Task.Run(() =>
        {
            pos /= cellSize;
            Vector2 cellPos = (pos % Vector2Int.One);

            Vector2 gridPoint0 = pos.RemoveFractionalPart();
            Vector2 gridPoint1 = (Vector2Int)gridPoint0 + Vector2Int.One;

            return new (Vector2, Vector2)[]
            {
            (-cellPos, noiseMap[gridPoint0]),
            ((Vector2)Vector2Int.Right - cellPos, noiseMap[gridPoint0.CombineX(gridPoint1)]),
            ((Vector2)Vector2Int.Down - cellPos, noiseMap[gridPoint0.CombineY(gridPoint1)]),
            ((Vector2)Vector2Int.One - cellPos, noiseMap[gridPoint1])
            };
        });
    }

    public async Task<float> GetNoiseAsync(Vector2 pos)
    {
        var gradientCorners = (await GetGradientVectorsAsync(pos))
        .Select(v => ComputeGradientContribution(v.Item1, v.Item2))
        .ToArray();

        pos /= cellSize;
        Vector2 cellPos = (pos % Vector2Int.One);
        cellPos.x = Interpolation.GetSinusInterpolationCoeficcient(cellPos.x);

        var interpolateBottom = Interpolation.Linear(gradientCorners[0], gradientCorners[1], cellPos.x);
        var interpolateTop = Interpolation.Linear(gradientCorners[2], gradientCorners[3], cellPos.x);

        float result = Interpolation.Sinus(interpolateBottom, interpolateTop, cellPos.y);

        return result / 2 + 0.5f;
    }

    public Task<float> GetNoiseAsync(float x,float y) => GetNoiseAsync(new Vector2(x,y));
    public float GetNoise(float x,float y) => GetNoiseAsync(new Vector2(x,y)).Result;


    private static float ComputeGradientContribution(Vector2 distanceVector,Vector2 gridVector) => distanceVector.DotProduct(gridVector);
}