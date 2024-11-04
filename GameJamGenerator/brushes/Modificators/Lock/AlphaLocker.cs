using Colors;

public class AlphaLocker :BrushComparator<Color>
{
    public AlphaLocker(IBrush<Color> originalBrush) : base(originalBrush)
    {
    }

    protected override Color CompareValues(Color orig,Color brushOut) => new Color(brushOut.R, brushOut.G, brushOut.B,orig.A);
}