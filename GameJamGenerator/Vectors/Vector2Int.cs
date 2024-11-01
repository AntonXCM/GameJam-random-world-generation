using System.Collections;

public struct Vector2Int : IEnumerator<int>, IEnumerable,ICollection
{
    /// <summary>
    /// (0,0)
    /// </summary>
    public static Vector2Int Zero => new(0, 0);
    /// <summary>
    /// (1,1)
    /// </summary>
    public static Vector2Int One => new(1, 1);
    /// <summary>
    /// (-1,0)
    /// </summary>
    public static Vector2Int Left => new(-1, 0);
    /// <summary>
    /// (1,0)
    /// </summary>
    public static Vector2Int Right => new(1, 0);
    /// <summary>
    /// (0,-1)
    /// </summary>
    public static Vector2Int Up => new(0, -1);
    /// <summary>
    /// (0,1)
    /// </summary>
    public static Vector2Int Down => new(0, 1);
    public int x, y;
    public readonly double Magnitude => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));


    public static implicit operator Vector2Int(Vector2 vector) => new((int)Math.Round(vector.x), (int)Math.Round(vector.y));

    public Vector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Vector2Int(bool x, bool y) : this(x?1:-1,y?1:-1) {}

    public Vector2Int(Vector2 vector) : this((int)Math.Round(vector.x), (int)Math.Round(vector.y)) { }
    public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new(a.x + b.x, a.y + b.y);
    public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new(a.x - b.x, a.y - b.y);
    public static Vector2Int operator -(Vector2Int a) => a*-1;
    public static Vector2Int operator *(Vector2Int a, int b) => new(a.x * b, a.y * b);
    public static Vector2 operator *(Vector2Int a, float b) => new(a.x * b, a.y * b);
    public static Vector2Int operator /(Vector2Int a, int b) => new(a.x / b, a.y / b);
    public static Vector2 operator /(Vector2Int a, float b) => new(a.x / b, a.y / b);
    public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new(a.x / b.x, a.y / b.y);
    public static bool operator ==(Vector2Int a, Vector2Int b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector2Int a, Vector2Int b) => a.x != b.x || a.y != b.y;
    public static bool operator >(Vector2Int a, Vector2Int b) => b < a;
    public static bool operator <(Vector2Int a, Vector2Int b) => a.x < b.x && a.y < b.y;
    public static bool operator >=(Vector2Int a, Vector2Int b) => b <= a;
    public static bool operator >=(Vector2Int a, int b) => a.x >= b && a.y >= b;
    public static bool operator <=(Vector2Int a, int b) => a.x <= b && a.y <= b;
    public static bool operator <=(Vector2Int a, Vector2Int b) => a.x <= b.x && a.y <= b.y;
    public static bool operator ==(Vector2Int a, Vector2 b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector2Int a, Vector2 b) => a.x != b.x || a.y != b.y;
    public static implicit operator Vector2Int(Direction direction) => direction.ToVector();
    public readonly override bool Equals(object? obj)
    {
        if (obj is Vector2Int vectorInt) return this == vectorInt;
        else if (obj is Vector2 vector) return this == vector;
        return false;
    }
    public readonly override int GetHashCode()=> base.GetHashCode();
    public readonly override string? ToString() => $"X = {x}, Y = {y}, Длина = {Magnitude}";

    //Реализация IEnumerator
    bool currentIsX = true;
    public int Current => currentIsX ? x : y;
    object IEnumerator.Current => Current;

    public int Count => 2;
    public bool IsSynchronized => true;
    public object SyncRoot { get; private set; }

    public bool MoveNext()
    {
        currentIsX = !currentIsX;
        return !currentIsX;
    }
    public void Reset() => currentIsX = true;
    public void Dispose() => Reset();
    public IEnumerator GetEnumerator() => this;

    public void CopyTo(Array array, int index)
    {
        foreach(int i in this)
            array.SetValue(i,index++);
    }
}
