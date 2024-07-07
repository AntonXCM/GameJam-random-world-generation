
public class GeneratorFactory : GameGenerator
{
    public override Grid Generate(int playerX) => new ClosedExit().Generate(playerX);
}