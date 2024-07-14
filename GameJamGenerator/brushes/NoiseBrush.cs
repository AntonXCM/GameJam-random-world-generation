public class NoiseBrush<T> : IBrush<T>
{
    readonly T[] noiseComonents;
    public NoiseBrush((T component, int probablity)[] noiseComonents)
    {
        List<T> noises = new(noiseComonents.Length);
        foreach (var (component, probablity) in noiseComonents)
            for (int i = 0; i < probablity; i++)
                noises.Add(component);
        this.noiseComonents = [.. noises];
    }
    public T GetValue(int x, int y, T current) => noiseComonents[GlobalGenRandom.Next(0, noiseComonents.Length - 1)];
}