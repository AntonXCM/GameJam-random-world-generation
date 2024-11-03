namespace Colors;

public struct Color
{
    public int R, G, B, A;
    public static Color AntiqueWhite => System.Drawing.Color.AntiqueWhite;
    public static Color CadetBlue => System.Drawing.Color.CadetBlue;
    public Color(int r,int g,int b,int a = 255)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }
    public override string ToString()
    {
        return $"Color [R={R}, G={G}, B={B}, A={A}]";
    }

    public string ToHex()
    {
        return $"#{R:X2}{G:X2}{B:X2}{A:X2}";
    }

    public static Color Lerp(Color c1,Color c2,float t)
    {
        t = Math.Clamp(t,0f,1f);
        int r = (int)(c1.R + (c2.R - c1.R) * t);
        int g = (int)(c1.G + (c2.G - c1.G) * t);
        int b = (int)(c1.B + (c2.B - c1.B) * t);
        int a = (int)(c1.A + (c2.A - c1.A) * t);
        return new Color(r,g,b,a);
    }

    public static implicit operator System.Drawing.Color(Color c)
    {
        return System.Drawing.Color.FromArgb(Clamp(c.A),Clamp(c.R),Clamp(c.G),Clamp(c.B));
        int Clamp(int value) => Math.Clamp(value, 0, 255);
    }

    public static implicit operator Color(System.Drawing.Color c) => new Color(c.R,c.G,c.B,c.A);

    public static Color operator +(Color a,Color b) => new Color(a.R + b.R,a.G + b.G,a.B + b.B,a.A + b.A);
    public static Color operator -(Color a,Color b) => new Color(a.R - b.R,a.G - b.G,a.B - b.B,a.A - b.A);
    public static Color operator *(Color c,int multiplier) => new Color(c.R * multiplier,c.G * multiplier,c.B * multiplier,c.A * multiplier);
    public static Color operator /(Color c,int divisor) => new Color(c.R / divisor,c.G / divisor,c.B / divisor,c.A / divisor);
}