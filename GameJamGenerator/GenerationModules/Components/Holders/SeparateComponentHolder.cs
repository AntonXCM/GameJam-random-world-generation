public class SeparateComponentHolder<T>(T owner) : SeparateComponentHolder<T, IComponent<T>>(owner){}
public class SeparateComponentHolder<T, ComponenT>(T owner) : SeparateComponentHolder(owner), IComponentHolder<ComponenT> where ComponenT : IComponent<T>
{
    readonly List<ComponenT> Components = [];

    public override void AddComponent<TOwner>(IComponent<TOwner> component)
    {
        base.AddComponent(component);
        AddComponent((ComponenT)component);
    }
    public void AddComponent(ComponenT component)
    {
        if (component == null) throw new ArgumentNullException("Null компонент");
        Components.Add(component);
        component.OnAdd((T)Owner);
    }

    public override void RemoveComponent<TOwner>(IComponent<TOwner> component) => RemoveComponent(component as ComponentBase<T>);
    public void RemoveComponent(ComponenT component)
    {
        if (!Components.Contains(component)) throw new InvalidOperationException($"Невозможно удалить {(component.HolderObject == null ? "ничей" : "чужой")} компонент!");
        Components.Remove(component);
        component.OnRemove();
    }
}
public abstract class SeparateComponentHolder
{
    public object Owner { get; private set; }

    protected SeparateComponentHolder(object owner)
    {
        if (owner == null) throw new ArgumentNullException("То, что держатель отделен не значит, что он самостоятелен");
        else if (owner == this) throw new InvalidOperationException("Чел, ты...");
        Owner = owner;
    }

    public static SeparateComponentHolder GetFromObject<TOwner>(TOwner owner) => new SeparateComponentHolder<TOwner>(owner);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Удалите неиспользуемый параметр", Justification = "<Так надо>")]
    public static SeparateComponentHolder GetFromObject<TOwner, ComponenT>(TOwner owner, ComponenT componentType) where ComponenT : ComponentBase<TOwner> => new SeparateComponentHolder<TOwner, ComponenT>(owner);
    public virtual void AddComponent<TOwner>(IComponent<TOwner> component)
    {
        if (!Owner.GetType().IsSubclassOf(typeof(TOwner))) throw new InvalidOperationException("Не подходящий компонент)");
    }
    public abstract void RemoveComponent<TOwner>(IComponent<TOwner> component);
}