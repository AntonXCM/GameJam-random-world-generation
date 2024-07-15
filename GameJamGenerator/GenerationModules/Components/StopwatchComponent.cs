using System.Diagnostics;

public class StopwatchComponent<T> : GenerationModuleComponent<T>
{
    readonly Stopwatch stopwatch = new();
    protected override GenerationModule<T>.BeforeIterationActionDelegate BeforeIterationAction => stopwatch.Start;
    protected override GenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => () =>
    {
        stopwatch.Stop();
        Console.WriteLine($"Модуль генерации {Holder.GetType().Name} закончил за {stopwatch.Elapsed} секунд");
    };
}