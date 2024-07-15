public abstract class IteratorGenerationModule<T> : GenerationModule<T>
{
    protected IteratorGenerationModule(IComponent<GenerationModule<T>>[] components = null) : base(components){}
    public override void Generate(ref IGrid<T> grid)
    {
        base.Generate(ref grid);
        Iterate();
        AfterIteration();
    }
    protected abstract void Iterate();
    public abstract bool Action(Vector2Int pos);
}