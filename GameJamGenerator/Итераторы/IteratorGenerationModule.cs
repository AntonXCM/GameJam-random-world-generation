public abstract class IteratorGenerationModule<T> : GenerationModule<T>
{
    public override void Generate(ref IGrid<T> grid)
    {
        base.Generate(ref grid);
        BeforeIterationAction?.Invoke();
        Iterate();
         AfterIterationAction?.Invoke();
    }
    protected abstract void Iterate();
    public abstract bool Action(Vector2Int pos);
    public delegate void BeforeIterationActionDelegate();
    public delegate void  AfterIterationActionDelegate();
    public event BeforeIterationActionDelegate BeforeIterationAction;
    public event  AfterIterationActionDelegate  AfterIterationAction;
}