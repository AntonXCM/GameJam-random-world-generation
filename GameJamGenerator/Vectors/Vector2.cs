public struct Vector2
{
    public float x, y;
    public static Vector2 Random => new(GlobalGenRandom.NextFloat() * (GlobalGenRandom.NextBool() ? -1 : 1), GlobalGenRandom.NextFloat() * (GlobalGenRandom.NextBool() ? -1 : 1));
    public Vector2(Vector2Int vector) : this(vector.x, vector.y) { }
    public Vector2(float x, float y)
    {
        this.y = y;
        this.x = x;
    }
    public double Magnitude
    {
        readonly get => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        set => this *= value / Magnitude;
    }
    public double Angle
    {
        get => Math.Atan2(-y, x) * (180 / Math.PI);
    }
    public const int Dimensions = 2;

    public float this[int dimension]
    {
        readonly get => dimension switch
        {
            0 => x,
            1 => y,
            _ => throw new ArgumentOutOfRangeException("Есть только X и Y"),
        };
        set
        {
            switch(dimension)
            {
                case 0: x = value; break;
                case 1: y = value; break;
                default: throw new ArgumentOutOfRangeException("Есть только X и Y");
            }
        }
    }
    public void Normalize() => Magnitude = 1;
    public void NormalizeMin1()
    {
        Normalize();
        float minValue = Math.Abs(x);
        if(Math.Abs(y) > minValue && y != 0)
            minValue = y;
        if(minValue != 0)
            this /= Math.Abs(minValue);
    }
    public static implicit operator Vector2(Vector2Int vector) => new(vector.x, vector.y);
    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.x + b.x, a.y + b.y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.x - b.x, a.y - b.y);
    public static Vector2 operator *(Vector2 a, double b) => new((float)(a.x * b), (float)(a.y * b));
    public static Vector2 operator /(Vector2 a, double b) => new((float)(a.x / b), (float)(a.y / b));
    public override string ToString() => $"{x}, {y}";
    public char ToSymbol()
    {
        double angle = Angle;
        if(angle >= -22.5 && angle < 22.5)
            return '>'; 
        else if(angle >= 22.5 && angle < 67.5)
            return '7'; 
        else if(angle >= 67.5 && angle < 112.5)
            return '^'; 
        else if(angle >= 112.5 && angle < 157.5)
            return 'г'; 
        else if(angle >= -67.5 && angle < -22.5)
            return '\\'; 
        else if(angle >= -112.5 && angle < -67.5)
            return 'v'; 
        else if(angle >= -157.5 && angle < -112.5)
            return 'L'; 
        return '<'; 
    }

}