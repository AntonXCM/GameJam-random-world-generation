public class SeparateGenerationComponentHolder<ModuleT> : SeparateComponentHolder<ModuleT, IComponent<ModuleT>>
{
    public SeparateGenerationComponentHolder(ModuleT owner) : base(owner)
    { }
    public static SeparateGenerationComponentHolder<TModule> GetFromOwner<TModule>(TModule module) => new SeparateGenerationComponentHolder<TModule>(module);
}