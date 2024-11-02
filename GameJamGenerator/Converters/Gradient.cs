public class Gradient<T>
{
    private (T value, float position)[] gradientPoints;
    public Func<T,T,float,T> InterpolationFunc { get; set; }

    public Gradient((T iTem, float position)[] gradientPoints,Func<T,T,float,T> interpolationFunc)
    {
        if(gradientPoints.Length < 2)
            throw new ArgumentException("Должно быть как минимум два значения с позициями в градиенте.");

        Array.Sort(gradientPoints,(a,b) => a.position.CompareTo(b.position));
        this.gradientPoints = gradientPoints;
        InterpolationFunc = interpolationFunc ?? throw new ArgumentNullException(nameof(interpolationFunc));
    }
    public Func<float,T> Func => f => this[f];
    public T this[float position]
    {
        get
        {
            if(position <= gradientPoints[0].position) return gradientPoints[0].value;
            if(position >= gradientPoints[^1].position) return gradientPoints[^1].value;

            int left = 0;
            int right = gradientPoints.Length - 1;

            while(left <= right)
            {
                int mid = (left + right) / 2;

                if(gradientPoints[mid].position == position)
                    return gradientPoints[mid].value;
                else if(gradientPoints[mid].position < position)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            int index = Math.Max(0, left - 1);
            float range = gradientPoints[index + 1].position - gradientPoints[index].position;
            float fraction = (position - gradientPoints[index].position) / range;
            return InterpolationFunc(gradientPoints[index].value,gradientPoints[index + 1].value,fraction);
        }
    }
}