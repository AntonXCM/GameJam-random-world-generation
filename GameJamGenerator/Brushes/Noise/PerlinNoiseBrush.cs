using MathA;

public class PerlinNoiseBrush<T> :PerlinNoise, IBrush<T>
{
    public PerlinNoiseBrush(VectorGrid noiseMap, Vector2 cellSize, Func<float, T> floatToTile) : base(noiseMap, cellSize) => this.floatToTile = floatToTile;

    readonly Func<float, T> floatToTile;

    public T GetValue(int x, int y, T current) => floatToTile(GetValue(x, y));
}