internal struct Vector2Int
{
    public static Vector2Int Zero => new(0, 0);
    public static Vector2Int one => new(1, 1);
    public static Vector2Int left => new(-1, 0);
    public static Vector2Int right => new(1, 0);
    public static Vector2Int up => new(0, -1);
    public static Vector2Int down => new (0, 1);
    public int x;
    public int y;
    public double magnitude
    {
        get { return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)); }
    }
    public Vector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static implicit operator Vector2Int(Vector2 vector) => new((int)Math.Round(vector.x), (int)Math.Round(vector.y));
    public Vector2Int(Vector2 vector) : this((int)vector.x, (int)vector.y) {}
    public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
    public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);
    public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.x * b, a.y * b);
    public static Vector2Int operator /(Vector2Int a, int b) => new Vector2Int(a.x / b, a.y / b);
    public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.x / b.x, a.y / b.y);
    public static bool operator ==(Vector2Int a, Vector2Int b) => a.x==b.x&&a.y==b.y;
    public static bool operator !=(Vector2Int a, Vector2Int b) => a.x!=b.x||a.y!=b.y;
}
