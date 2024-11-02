namespace MathA;

public class PerlinNoise : Upscaler2D<Vector2,float>
{
    public PerlinNoise(IGrid<Vector2> vectorGrid, Vector2 cellSize) : base(vectorGrid,cellSize){}

    protected override float DoFinalProcess(float input) => input / 2 + 0.5f;

    protected override float Interploate(float a,float b,float t) => Interpolation.Linear(a,b,t);

    protected override float ProcessNeighbor(NeighborData neighbor) => neighbor.inputValue.DotProduct(neighbor.relativeOffset);
}