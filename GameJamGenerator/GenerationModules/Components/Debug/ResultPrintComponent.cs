public class ResultPrintComponent<T> : GenerationModuleComponent<T>
{
    private int MillisecondsTimeout;

    public ResultPrintComponent(int millisecondsTimeout = 500) => MillisecondsTimeout = millisecondsTimeout;

    protected override GenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => () =>
    {
        Console.WriteLine(Holder.LookAtGrid.ToString());
        Thread.Sleep(MillisecondsTimeout);
    };
}