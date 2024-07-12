public class ComponentBase<THolder> : IDisposable
{
    public THolder holder { get; private set; }

    public virtual void Dispose(){} 
    public virtual void OnAdd(THolder holder) => this.holder = holder; 
    public virtual void OnRemove() => Dispose();
}