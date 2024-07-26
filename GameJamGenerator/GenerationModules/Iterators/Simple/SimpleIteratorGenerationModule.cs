
public abstract class SimpleIteratorGenerationModule<T> : IteratorGenerationModule<T>
{
    protected ActionStopMode actionStopMode;
    protected Direction direction
    {
        set
        {
            innerDir = value.ToVector();
            outerDir = innerDir.Perpendicular();
        }
    }
    RectInt iterationRect => iteratingGrid.SizeRect&CutoutRect;
    virtual protected RectInt CutoutRect => new(Vector2Int.One * int.MinValue, Vector2Int.One * int.MaxValue);
    protected Vector2Int innerDir, outerDir;
    protected SimpleIteratorGenerationModule(IComponent<GenerationModule<T>>[] components = null) : base(components){}

    protected override void Iterate() => Iterate();
    protected void Iterate(List<int>? ignoreList = null) => iterationRect.Iterate(Action, innerDir,outerDir, ignoreList, actionStopMode);
}