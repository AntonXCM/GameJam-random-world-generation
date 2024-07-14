public class ComponentBase<THolder> : IDisposable, IComponent<THolder>
{
    public THolder holder { get; private set; }

    public object Holder => holder;

    public virtual void Dispose() { }
    public virtual void OnAdd(THolder holder) => this.holder = holder;
    public virtual void OnRemove() => Dispose();
}