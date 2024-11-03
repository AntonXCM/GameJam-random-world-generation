namespace MathA;
public abstract class Upscaler2D<Input, Output>
{
    public IGrid<Input> oldGrid;
    public readonly Vector2 cellSize = new(4, 4);
    RectInt nearestRect = new RectInt(Vector2Int.Zero,Vector2Int.One);
    public Upscaler2D(IGrid<Input> oldGrid,Vector2 cellSize)
    {
        this.oldGrid = oldGrid;
        this.cellSize = cellSize;
    }

    public Output GetValue(Vector2 pos)
    {
        Vector2 cellPos = pos / cellSize % Vector2Int.One;

        Output result;

        var gradientCorners = GetNeighbors(pos)
            .Select(n => ProcessNeighbor(n))
            .ToArray();
        if(cellPos == (Vector2)Vector2Int.Zero)
        {
            result = gradientCorners[0];
        }
        else if(cellPos.x == 0 || cellPos.y == 0)
        {
            result = Interploate(gradientCorners[0],gradientCorners[1], InterpolationForm(cellPos.y + cellPos.x));
        }
        else
        {
            cellPos.x = InterpolationForm(cellPos.x);

            Output interpolateBottom = Interploate(gradientCorners[0], gradientCorners[1], cellPos.x);
            Output interpolateTop =    Interploate(gradientCorners[2], gradientCorners[3], cellPos.x);

            result = Interploate(interpolateBottom,interpolateTop,InterpolationForm(cellPos.y));
        }

        return DoFinalProcess(result);
    }

    public Output GetValue(float x,float y) => GetValue(new Vector2(x,y));
    protected NeighborData[] GetNeighbors(Vector2 pos)
    {
        pos /= cellSize;
        Vector2 cellPos = (pos % Vector2Int.One);
        Vector2Int gridPoint = pos.RemoveFractionalPart();
        List<NeighborData> neighbors = [];
        bool
            xCycleStopped = cellPos.x == 0,
            yCycleStopped = cellPos.y == 0;
        for (Vector2Int cell = new(xCycleStopped ? 0 : nearestRect.Min.x,yCycleStopped ? 0 : nearestRect.Min.y); cell.y <= nearestRect.Max.y; cell.y++)
        {
            for (; cell.x <= nearestRect.Max.x; cell.x++)
            {
                neighbors.Add(new((Vector2)cell - cellPos,oldGrid[(gridPoint + cell).ClampInGrid(oldGrid)]));
                if(xCycleStopped) break;
            }
            if(!yCycleStopped) cell.x = nearestRect.Min.x;
            else break;
        }
        return neighbors.ToArray();
    }
    protected abstract Output ProcessNeighbor(NeighborData neighbor);
    protected virtual float InterpolationForm(float t) => Interpolation.GetSinusInterpolationCoeficcient(t);
    protected abstract Output Interploate(Output a, Output b, float t);
    protected abstract Output DoFinalProcess(Output input);
    protected record NeighborData(Vector2 relativeOffset,Input inputValue);
}