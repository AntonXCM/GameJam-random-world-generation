using System.Text;

public abstract class MatrixBase<T> : GridBase<T> where T : notnull
{
    public override string ToString()
    {
        int TileLength = Math.Max(this.GetMaxValue(ToNumber).ToString().Length,this.GetMinValue(ToNumber).ToString().Length);
        int LineLength = Width * (TileLength + 1) + 1;
        StringBuilder picture = new(LineLength * Height * 2);
        for(int j = 0; j < Height; j++)
        {
            for(int i = 0; i < LineLength; i++)
                picture.Append('─');
            picture.Append('\n');
            for(int i = 0; i < Width; i++)
            {
                string element = this[i, j].ToString();
                while(element.Length < TileLength) element += " ";
                picture.Append('│' + element);
            }
            picture.Append('\n');
        }
        return picture.ToString();
    }
    protected abstract double ToNumber(T value);
}