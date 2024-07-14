public class ComponentBase<THolder> : IDisposable, IComponent<THolder>
{
    public THolder Holder { get; private set; }

    public object HolderObject => Holder;

    public virtual void Dispose() { }
    public virtual void OnAdd(THolder holder) => Holder = holder;
    public virtual void OnRemove() => Dispose();
}