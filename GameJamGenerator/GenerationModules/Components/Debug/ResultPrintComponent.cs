public class ResultPrintComponent<T> : GenerationModuleComponent<T>
{
    protected override GenerationModule<T>.AfterIterationActionDelegate AfterIterationAction => ()=>Console.WriteLine(Holder.LookAtGrid.ToString());
}