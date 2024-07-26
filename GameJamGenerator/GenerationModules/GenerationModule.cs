public abstract partial class GenerationModule<T>
{
    protected IteratingGrid iteratingGrid;
    /// <summary>
    /// Я ценю инкапсуляцию, так что, мы можем получить только копию самой сетки. Поплачь об этом >:^)
    /// </summary>
    public IGrid<T> LookAtGrid => iteratingGrid.LookAtGrid;
    protected int Rows { get; private set; }
    protected int Cols { get; private set; }
    public SeparateComponentHolder componentHolder;
    public GenerationModule(IComponent<GenerationModule<T>>[] components)
    {
        componentHolder = SeparateComponentHolder.GetFromObject(this);
        if(components == null) return;
        foreach(var component in components)
            componentHolder.AddComponent(component);
    }

    public virtual void Generate(ref IGrid<T> grid)
    {
        Initialze(ref grid);
        BeforeIterationAction?.Invoke();
    }
    protected virtual void Initialze(ref IGrid<T> grid)
    {
        iteratingGrid = new(grid, ref OnDrawTile);
        Rows = grid.Width;
        Cols = grid.Height;
    }
    public delegate void BeforeIterationActionDelegate();
    public delegate void AfterIterationActionDelegate();
    public event BeforeIterationActionDelegate BeforeIterationAction;
    public event AfterIterationActionDelegate AfterIterationAction;
    protected void AfterIteration() => AfterIterationAction?.Invoke();
    public void DrawTile(Vector2Int pos, T value) => iteratingGrid.DrawTile(pos, value);
    public delegate void OnDrawTileDelegate(Vector2Int pos, T value, T lastValue);
    public event OnDrawTileDelegate OnDrawTile;
}