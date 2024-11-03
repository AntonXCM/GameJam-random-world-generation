using System.Drawing;

namespace MathA;

public static class Interpolation
{
    public static float Sinus(float a,float b,float t) => Linear(a,b,GetSinusInterpolationCoeficcient(t));
    public static float GetSinusInterpolationCoeficcient(float t) => 0.5f - (float)Math.Cos(t * Math.PI) / 2;
    public static float Qadratic(float a,float b,float t) => Linear(a,b,t*t);
    public static float Constant(float a,float b,float t) => t > 0.5 ? b : a;
    public static float Random(float a,float b,float t) => t > GlobalGenRandom.NextDouble() ? b : a;
    public static float Linear(float a,float b,float t) => a + (b - a) * t;
    public static class Colorful
    {
        public static Color Random(Color a,Color b,float t) => t > GlobalGenRandom.NextDouble() ? b : a;
        public static Color RandomSeparate(Color a,Color b,float t) => Functional(a,b,t,(a,b,t) => (byte)Interpolation.Random(a,b,t));
        public static Color Constant(Color a,Color b,float t) => (t > 0.5f) ? b : a;
        public static Color Linear(Color a,Color b,float t) => Functional(a,b,t,(a,b,t)=>(byte)Interpolation.Linear(a,b,t));
        public static Color Sinus(Color a,Color b,float t) => Functional(a,b,t,(a,b,t)=>(byte)Interpolation.Sinus(a,b,t));
        public static Color Functional(Color a,Color b,float t,Func<byte,byte,float,byte> func) => Color.FromArgb(
                func(a.A,b.A,t),
                func(a.R,b.R,t),
                func(a.G,b.G,t),
                func(a.B,b.B,t));

    }
}