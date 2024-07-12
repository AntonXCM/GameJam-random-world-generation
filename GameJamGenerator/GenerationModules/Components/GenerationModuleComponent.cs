public abstract class GenerationModuleComponent<T, THolder> : ComponentBase<THolder> where THolder : GenerationModule<T> 
{ 
    protected virtual GenerationModule<T>.OnDrawTileDelegate OnDrawTile { get => null; }
    public override void OnAdd(THolder holder)
    {
        base.OnAdd(holder);
        if(OnDrawTile != null) holder.OnDrawTile += OnDrawTile;
    }
    public override void OnRemove()
    {
        base.OnRemove();
        if (OnDrawTile!=null) holder.OnDrawTile -= OnDrawTile;
    }
}
public abstract class GenerationModuleComponent<T> : GenerationModuleComponent<T, GenerationModule<T>>{}
public abstract class IteratorGenerationModuleComponent<T, THolder> : GenerationModuleComponent<T,THolder> where THolder : IteratorGenerationModule<T>
{
    public virtual IteratorGenerationModule<T>.BeforeIterationActionDelegate BeforeIterationAction { get => null; }
    public virtual IteratorGenerationModule<T>. AfterIterationActionDelegate  AfterIterationAction { get => null; }
    public override void OnAdd(THolder holder)
    {
        base.OnAdd(holder);
        if (BeforeIterationAction != null) holder.BeforeIterationAction += BeforeIterationAction;
        if ( AfterIterationAction != null) holder. AfterIterationAction +=  AfterIterationAction;
    }
    public override void OnRemove()
    {
        base.OnRemove();
        if (BeforeIterationAction != null) holder.BeforeIterationAction -= BeforeIterationAction;
        if ( AfterIterationAction != null) holder. AfterIterationAction -=  AfterIterationAction;
    }
}
public abstract class IteratorGenerationModuleComponent<T> : IteratorGenerationModuleComponent<T, IteratorGenerationModule<T>>{} 