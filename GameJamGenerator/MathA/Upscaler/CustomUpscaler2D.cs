namespace MathA;
public class CustomUpscaler2D<Input, Output> :Upscaler2D<Input,Output>
{
    public Func<Output, Output> FinalProcessorFunc;
    protected override Output DoFinalProcess(Output input) => FinalProcessorFunc(input);
    
    
    public Func<float, float> InterpolationFormFunc;
    protected override float InterpolationForm(float t) => InterpolationFormFunc(t);

    public Func<Output, Output,float, Output> InterpolationFunc;
    protected override Output Interploate(Output a,Output b,float t) => InterpolationFunc(a,b,t);


    public Func<Input, Vector2, Output> NeighborProcessorFunc;
    protected override Output ProcessNeighbor(NeighborData neighbor) => NeighborProcessorFunc(neighbor.inputValue,neighbor.relativeOffset);

    public CustomUpscaler2D(IGrid<Input> oldGrid,Vector2 cellSize,Func<Output,Output,float,Output> interpolationFunc,Func<Input,Vector2,Output> neighborProcessorFunc,Func<Output,Output> finalProcessorFunc = null,Func<float,float> interpolationFormFunc = null): base(oldGrid,cellSize)
    {
        InterpolationFunc = interpolationFunc ??            throw new ArgumentNullException(nameof(interpolationFunc));
        NeighborProcessorFunc = neighborProcessorFunc ??    throw new ArgumentNullException(nameof(neighborProcessorFunc));
        FinalProcessorFunc = finalProcessorFunc ?? (o=>o);
        InterpolationFormFunc = interpolationFormFunc ?? base.InterpolationForm;
    }

}