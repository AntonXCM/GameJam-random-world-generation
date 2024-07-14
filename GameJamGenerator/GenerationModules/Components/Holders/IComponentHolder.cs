public interface IComponentHolder<ComponenT> 
{
    void AddComponent(ComponenT component);
    void RemoveComponent(ComponenT component);
}