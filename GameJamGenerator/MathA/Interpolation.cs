namespace MathA;

public static class Interpolation
{
    public static float Sinus(float a,float b,float t) => Linear(a,b,GetSinusInterpolationCoeficcient(t));
    public static float GetSinusInterpolationCoeficcient(float t) => 0.5f - (float)Math.Cos(t * Math.PI) / 2;
    public static float Qadratic(float a,float b,float t) => Linear(a,b,t*t);
    public static float Linear(float a,float b,float t)
    {
        return a + (b-a)*t;
    }
}