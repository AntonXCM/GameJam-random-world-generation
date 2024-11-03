using Colors;
using System;
using MathA;

internal class River :GameGenerator
{
    public override IGrid Generate(int playerX)
    {
        return ColorGrid.ToBitmapGrid((ColorGrid)
            //new GridSharpener<Color>((c,i)=>c*i,(a,b)=>a+b).GenerateReturn(
            new GridUpscaler<Color>(3,Color.Lerp,interpolationFormFunc: f=>f).GenerateXtimes(
            new BucketFill<Color>([Vector2Int.Zero],[],new PerlinNoiseBrush<Color>(new(50,50,1),new(23,23),
            new Gradient<Color>([
                (Color.AntiqueWhite, 0.52f),
                (Color.CadetBlue, 0.51f),
                (Color.CadetBlue, 0.48f),
                (Color.AntiqueWhite, 0.47f)],
            Color.Lerp
            ).Func)).GenerateReturn(new ColorGrid(110,60)),3));
    }
}