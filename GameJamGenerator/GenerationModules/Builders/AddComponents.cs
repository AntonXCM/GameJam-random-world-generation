public static class ComponentsBuilder
{
    public static ClassT AddComponents<ClassT, T>(this ClassT @class, params T[] components) where ClassT : IComponentHolder<T> where T : IComponent<ClassT>
    {
        foreach(var component in components)
            @class.AddComponent(component);
        return @class;
    }
}