using System.Diagnostics;

public class StopwatchComponent<T> : IteratorGenerationModuleComponent<T>
{
    Stopwatch stopwatch = new();
    public override IteratorGenerationModule<T>.BeforeIterationActionDelegate BeforeIterationAction => stopwatch.Start;
    public override IteratorGenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => () =>
    {
        stopwatch.Stop();
        Console.WriteLine($"Модуль генерации {holder.GetType().Name} закончил за {stopwatch.Elapsed} секунд");
    };
}