public class SeparateGenerationComponentHolder<ModuleT>(ModuleT owner) : SeparateComponentHolder<ModuleT, IComponent<ModuleT>>(owner)
{
    public static SeparateGenerationComponentHolder<TModule> GetFromOwner<TModule>(TModule module) => new(module);
}