/// <summary>
/// <see cref="Direction"/> - это enum, упрощающий использование векторов для направлений. Каждые два бита означают координату. Первый бит - её наличие, а второй - отрицательность.
/// К примеру, 1000 - это право, 1100 - лево, 0010 - вниз и т.д. При создании собственных направлений, добавляйте им значения.
/// </summary>
public enum Direction
{
    /// <summary>
    /// (1,0)
    /// </summary>
    Right = 0b_1000_0000, 
    /// <summary>
    /// (-1,0)
    /// </summary>
    Left = 0b_1100_0000, 
    /// <summary>
    /// (0,-1)
    /// </summary>    
    Up = 0b_0011_0000, 
    /// /// <summary>
    /// (0,1)
    /// </summary>
    Down = 0b_0010_0000
}
public static class DirectionExtentions
{
    /// <summary>
    /// Переводит <see cref="Direction"/> в <see cref="Vector2Int"/> по правилам шифровки <see cref="Direction"/>. 
    /// </summary>
    /// <param name="direction"><see cref="Direction"/>, которое вы переводите</param>
    /// <returns>Первые два бита переводятся в <see cref="Vector2Int.x"/>, вторые переводятся в <see cref="Vector2Int.y"/>, а мнение остальных не учитывается :)</returns>
    public static Vector2Int ToVector(this Direction direction)
    {
        byte value = (byte)direction;
        return new(
            ((value & 0b_1000_0000) != 0 ? 1 : 0) * ((value & 0b_0100_0000) != 0 ? -1 : 1),
            ((value & 0b_0010_0000) != 0 ? 1 : 0) * ((value & 0b_0001_0000) != 0 ? -1 : 1));
    }
}