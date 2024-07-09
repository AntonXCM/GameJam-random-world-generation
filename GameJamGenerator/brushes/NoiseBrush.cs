public class NoiseBrush<T> : IBrush<T>
{
    T[] noiseComonents;
    public NoiseBrush((T component,int probablity)[] noiseComonents)
    {
        List<T> noises = new(noiseComonents.Length);
        foreach (var noiseComonent in noiseComonents)
            for (int i = 0; i < noiseComonent.probablity; i++)
                noises.Add(noiseComonent.component);
        this.noiseComonents = noises.ToArray();
    }
    public T GetValue(int x, int y, T current) => noiseComonents[GlobalGenRandom.Next(0, noiseComonents.Length-1)];
}