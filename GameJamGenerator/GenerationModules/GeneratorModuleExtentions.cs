public static class GenerationModuleExtentions
{
    public static IGrid<T> GenerateXtimes<T>(this GenerationModule<T> generationModule, IGrid<T> grid, int times)
    {
        for(int i = 0; i < times; i++)
        {
            generationModule.Generate(ref grid);
        }
        return grid;
    }
}