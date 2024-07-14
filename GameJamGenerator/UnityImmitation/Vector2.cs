public struct Vector2
{
    public float x, y;
    public static Vector2 random => new(GlobalGenRandom.NextFloat() * (GlobalGenRandom.NextBool() ? -1 : 1), GlobalGenRandom.NextFloat() * (GlobalGenRandom.NextBool() ? -1 : 1));
    public double Magnitude
    {
        get => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        set
        {
            double multipliar = value / Magnitude;
            this *= multipliar;
        }
    }
    public int Dimensions => 2;
    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public float this[int dimension]
    {
        get
        {
            switch (dimension)
            {
                case 0: return x;
                case 1: return y;
                default: throw new ArgumentOutOfRangeException("Есть только X и Y");
            }
        }
        set
        {
            switch (dimension)
            {
                case 0: x = value; break;
                case 1: y = value; break;
                default: throw new ArgumentOutOfRangeException("Есть только X и Y");
            }
        }
    }
    public void Normalize()
    {
        Magnitude = 1;
    }
    public void NormalizeMin1()
    {
        Normalize();
        float minValue = Math.Abs(x);
        if (Math.Abs(y) > minValue && y != 0)
            minValue = y;
        if (minValue != 0)
            this /= Math.Abs(minValue);
    }
    public static implicit operator Vector2(Vector2Int vector) => new(vector.x, vector.y);
    public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
    public static Vector2 operator *(Vector2 a, double b) => new Vector2((float)(a.x * b), (float)(a.y * b));
    public static Vector2 operator /(Vector2 a, double b) => new Vector2((float)(a.x / b), (float)(a.y / b));
}