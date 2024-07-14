public interface IComponent<in THolder>
{
    object Holder { get; }
    void OnAdd(THolder holder);
    void OnRemove();
}