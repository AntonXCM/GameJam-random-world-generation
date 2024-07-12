public interface IComponentHolder<This>
{
    void AddComponent<ComponenT>(ComponenT component) where ComponenT : ComponentBase<This>;
    void RemoveComponent<ComponenT>(ComponenT component) where ComponenT : ComponentBase<This>;
}