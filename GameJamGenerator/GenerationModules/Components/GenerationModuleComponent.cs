/// <summary>
/// Компонент для модуля генерации
/// </summary>
/// <typeparam name="T"> Тип тайлов модуля генерации</typeparam>
/// <typeparam name="THolder"> Тип модуля генерации</typeparam>
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
    protected void onAdd(THolder holder) => OnAdd(holder);
}
public abstract class GenerationModuleComponent<T> : GenerationModuleComponent<T, GenerationModule<T>>{}
public abstract class IteratorGenerationModuleComponent<T, THolder> : GenerationModuleComponent<T,THolder>, IComponent<GenerationModule<T>> where THolder : IteratorGenerationModule<T>
{
    public virtual IteratorGenerationModule<T>.BeforeIterationActionDelegate BeforeIterationAction { get => null; }
    public virtual IteratorGenerationModule<T>. AfterIterationActionDelegate  AfterIterationAction { get => null; }
    public override void OnAdd(THolder holder)
    {
        base.OnAdd(holder);
        if (BeforeIterationAction != null) holder.BeforeIterationAction += BeforeIterationAction;
        if ( AfterIterationAction != null) holder. AfterIterationAction +=  AfterIterationAction;
    }
    public void OnAdd(GenerationModule<T> holder)
    {
        onAdd(holder as THolder);
    }

    public override void OnRemove()
    {
        base.OnRemove();
        if (BeforeIterationAction != null) holder.BeforeIterationAction -= BeforeIterationAction;
        if ( AfterIterationAction != null) holder. AfterIterationAction -=  AfterIterationAction;
    }
}
public abstract class IteratorGenerationModuleComponent<T> : IteratorGenerationModuleComponent<T, IteratorGenerationModule<T>>{} 