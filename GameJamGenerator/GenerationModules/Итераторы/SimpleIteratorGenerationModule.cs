public abstract class SimpleIteratorGenerationModule<T> : IteratorGenerationModule<T>
{
    protected ActionStopMode actionStopMode;
    protected Direction direction = Direction.Right;
    protected override void Iterate() => Iterate();
    protected void Iterate(List<int>? ignoreList = null) => iteratingGrid.Iterate(Action, direction, ignoreList, actionStopMode);
}