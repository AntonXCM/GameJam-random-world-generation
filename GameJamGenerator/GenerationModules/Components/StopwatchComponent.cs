using System.Diagnostics;

public class StopwatchComponent<T> : IteratorGenerationModuleComponent<T>
{
    readonly Stopwatch stopwatch = new();
    public override IteratorGenerationModule<T>.BeforeIterationActionDelegate BeforeIterationAction => stopwatch.Start;
    public override IteratorGenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => () =>
    {
        stopwatch.Stop();
        Console.WriteLine($"Модуль генерации {Holder.GetType().Name} закончил за {stopwatch.Elapsed} секунд");
    };
}