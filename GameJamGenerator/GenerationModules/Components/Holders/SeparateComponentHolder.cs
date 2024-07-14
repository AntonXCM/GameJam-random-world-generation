using System.ComponentModel;

public class SeparateComponentHolder<T> : SeparateComponentHolder<T, IComponent<T>>
{
    public SeparateComponentHolder(T owner) : base(owner){}
}
public class SeparateComponentHolder<T,ComponenT> : SeparateComponentHolder, IComponentHolder<ComponenT> where ComponenT : IComponent<T>
{
    List<ComponenT> Components = [];
    public SeparateComponentHolder(T owner) : base(owner){}

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

    public override void RemoveComponent<TOwner>(ComponentBase<TOwner> component) => RemoveComponent(component as ComponentBase<T>);
    public void RemoveComponent(ComponenT component)
    {
        if (!Components.Contains(component)) throw new InvalidOperationException($"Невозможно удалить {(component.Holder == null ? "ничей" : "чужой")} компонент!");
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
    public static SeparateComponentHolder GetFromObject<TOwner,ComponenT>(TOwner owner, ComponenT componentType) where ComponenT : ComponentBase<TOwner> => new SeparateComponentHolder<TOwner,ComponenT>(owner);
    public virtual void AddComponent<TOwner>(IComponent<TOwner> component) 
    { 
        if (!Owner.GetType().IsSubclassOf(typeof(TOwner))) throw new InvalidOperationException("Не подходящий компонент)"); 
    }
    public abstract void RemoveComponent<TOwner>(ComponentBase<TOwner> component);
}