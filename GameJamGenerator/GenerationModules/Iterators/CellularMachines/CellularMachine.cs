/// <summary>
/// Подкласс модулей генерации, предназначенных для замены всех клеток сетки. Итерация непоследовательная, по этому старайтесь обеспечивать потокобезопасность.
/// </summary>
/// <typeparam name="T">Тип клеток сетки</typeparam>
public abstract class CellularMachine<T> : IteratorGenerationModule<T>
{
    protected IGrid<T> inputGrid;

    protected CellularMachine(IComponent<GenerationModule<T>>[] components = null) : base(components){}

    public override void Generate(ref IGrid<T> grid)
    {
        Initialze(ref grid);
        Iterate();
    }
    protected override void Iterate() => iteratingGrid.IterateParallel(pos => Action(pos));
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        inputGrid = (IGrid<T>)grid.Clone();
    }
}