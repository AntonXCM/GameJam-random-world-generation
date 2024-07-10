public abstract class IteratorGenerationModule<T> : GenerationModule<T>
{
    public override void Generate(ref IGrid<T> grid)
    {
        base.Generate(ref grid);
        Iterate();
    }
    protected abstract void Iterate();
    public abstract bool Action(Vector2Int pos);
}