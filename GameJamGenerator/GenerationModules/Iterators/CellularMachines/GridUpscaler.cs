#pragma warning disable CS8625 
using MathA;

public class GridUpscaler<T> :CellularMachine<T>
{ 
    CustomUpscaler2D<T,T> upscalerWorker;
    Vector2 sizeMultiplier;

    public GridUpscaler(float sizeMultiplier,Func<T,T,float,T> interpolationFunc,Func<T,Vector2,T> neighborProcessorFunc = null,Func<float,float> interpolationFormFunc = null) : this(new Vector2(sizeMultiplier,sizeMultiplier),interpolationFunc,neighborProcessorFunc,interpolationFormFunc) {}
    public GridUpscaler(Vector2 sizeMultiplier, Func<T,T,float,T> interpolationFunc,Func<T,Vector2,T> neighborProcessorFunc = null,Func<float,float> interpolationFormFunc = null)
    {
        this.upscalerWorker = new(null,sizeMultiplier,interpolationFunc,neighborProcessorFunc??((t,v) => t), interpolationFormFunc: interpolationFormFunc);
        this.sizeMultiplier = sizeMultiplier;
    }
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        Rows = (int)((Rows - 1) * sizeMultiplier.x);
        Cols = (int)((Cols - 1) * sizeMultiplier.y);
        upscalerWorker.oldGrid = inputGrid;
        iteratingGrid.ReplaceGrid(new T[Rows, Cols]);
    }
    
    public override bool Action(Vector2Int pos)
    {
        iteratingGrid[pos] = upscalerWorker.GetValue(pos);
        return false;
    }
}
#pragma warning restore CS8625 