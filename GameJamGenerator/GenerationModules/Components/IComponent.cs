public interface IComponent<in THolder>
{
    object HolderObject { get; }
    void OnAdd(THolder holder);
    void OnRemove();
}