public class TextureBrush<T> :IBrush<T>
{
    IGrid<T> texture;
    int textureX, textureY;
    public TextureBrush(IGrid<T> texture)
    {
        this.texture = texture;
        textureX = texture.Width;
        textureY = texture.Height;
    }
    public T GetValue(int x,int y,T current) => texture[x%textureX,y%textureY];
}