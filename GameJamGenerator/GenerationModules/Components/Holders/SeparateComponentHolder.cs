public class SeparateComponentHolder<T> : SeparateComponentHolder, IComponentHolder<T>
{
    List<ComponentBase<T>> Components = [];
    T owner;
    public SeparateComponentHolder(T owner) => this.owner = owner;

    public void AddComponent<ComponenT>(ComponenT component) where ComponenT : ComponentBase<T>
    {
        Components.Add(component);
        component.OnAdd(owner);
    }
    public void RemoveComponent<ComponenT>(ComponenT component) where ComponenT : ComponentBase<T>
    {
        if (!Components.Contains(component)) throw new InvalidOperationException($"Невозможно удалить {(component.holder == null ? "ничей" : "чужой")} компонент!");
        Components.Remove(component);
        component.OnRemove();
    }
}
public abstract class SeparateComponentHolder
{
    public static SeparateComponentHolder GetFromObject<T>(T t) => new SeparateComponentHolder<T>(t);
}