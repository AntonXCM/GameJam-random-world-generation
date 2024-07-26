namespace MathA;
public static class Checks
{
    public static bool IsInBounds(double value, double min, double max) => value >= min && value <= max;
    public static bool FirstIsPositive(params double[] digits) => digits[0] != 0 ? digits[0] >0:FirstIsPositive(digits.Skip(1).ToArray());
}