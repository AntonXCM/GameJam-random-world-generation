using Colors;
using System;
using MathA;
using System.Linq;

internal class River :GameGenerator
{
    public override IGrid Generate(int playerX)
    {
        return ColorGrid.ToBitmapGrid((ColorGrid)
            new BrushApplier<Color>(new AlphaLocker(new TextureBrush<Color>(ColorGrid.FromBitmapGrid(new BitmapGrid(new System.Drawing.Bitmap("C:/Users/Anton/вода.png")))))).GenerateReturn(
            new GridUpscaler<int>(2,Interpolation.Linear,interpolationFormFunc: f=>f).GenerateXtimes(
            new GridSharpener<int>((c,i)=>c*i,(a,b)=>a+b).GenerateXtimes(
            new BrushApplier<int>(new PerlinNoiseBrush<int>(new(50,50,1),new(24,24),
            new Gradient<int>([
                (0, 0.52f),
                (255, 0.51f),
                (255, 0.48f),
                (0, 0.47f)],
            Interpolation.Linear
            ).Func)).GenerateReturn(new IntMatrix(88,88)),1),4).Cast(i => new Color(0,0,0,i),new ColorGrid(1378,1378))));
    }
}