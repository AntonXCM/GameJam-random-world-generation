using System.Drawing;
using System;
using MathA;

internal class River :GameGenerator
{
    public override IGrid Generate(int playerX)
    {
        return new GridUpscaler<Color>(9,Interpolation.Colorful.Linear,interpolationFormFunc: f=>f).GenerateReturn(
            new BucketFill<Color>([Vector2Int.Zero],[],new PerlinNoiseBrush<Color>(new(50,50,1),new(17,17),
            new Gradient<Color>([
                (Color.ForestGreen, 0.52f),
                (Color.DarkBlue, 0.51f),
                (Color.DarkBlue, 0.48f),
                (Color.ForestGreen, 0.47f)],
                Interpolation.Colorful.Linear
            ).Func)).GenerateReturn(new BitmapGrid(88,88)));
    }
}