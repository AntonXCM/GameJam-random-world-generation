namespace MathA;

public static class Interpolation
{
    public static double Sinus(double a,double b,double t)
    {
        float factor = (float)(0.5 * (1 - Math.Cos(t * Math.PI)));
        return a * (1 - factor) + b * factor;
    }

}