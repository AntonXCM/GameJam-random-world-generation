public abstract class SimpleIteratorGenerationModule<T> : IteratorGenerationModule<T>
{
    protected ActionStopMode actionStopMode;
    protected Direction direction = Direction.Right;

    protected SimpleIteratorGenerationModule(IComponent<GenerationModule<T>>[] components = null) : base(components){}

    protected override void Iterate() => Iterate();
    protected void Iterate(List<int>? ignoreList = null) => iteratingGrid.Iterate(Action, direction, ignoreList, actionStopMode);
}