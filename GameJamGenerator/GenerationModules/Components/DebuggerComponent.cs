public class DebuggerComponent<T> : GenerationModuleComponent<T>
{
    protected override GenerationModule<T>.OnDrawTileDelegate OnDrawTile => (Vector2Int pos, T value, T lastValue) => Console.WriteLine(holder.LookAtGrid.ToString());
}