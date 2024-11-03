using System.Collections;
using System.Linq;
public class HolePuncher<T> : NearestCellOperator<T>, IHasBrush<T>
{
    public IBrush<T> Brush { get; set; }
    protected T Empty, Block;

    public HolePuncher(T empty,T block,IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        Empty = empty;
        Block = block;
        Mask = new(new bool[,]{{ false,true,false },
                                { true, true, true },
                                { false,true, false} });
    }
    public virtual bool CanMakeHole(T[] cross)
    {
        return cross[2].Equals(Block) && IsCross();
        bool IsCross()
        {
            T verticalTiles;
            if(!cross[0].Equals(cross[4])) return false;
            verticalTiles = cross[0];
            if(!verticalTiles.Equals(Block)&& !verticalTiles.Equals(Empty)) return false;

            T horysontallTiles;
            if(!cross[1].Equals(cross[3])) return false;
            horysontallTiles = cross[1];
            if(!verticalTiles.Equals(Block) && !verticalTiles.Equals(Empty)) return false;

            return !verticalTiles.Equals(horysontallTiles);
        }
    }

    protected override T CalculateValueFromCells(T[,] nearest,T[] nearestValues,Vector2Int pos)
    {
        IEnumerable<T> Cross()
            {
            foreach(var cell in nearest)
            {
                if(!cell.Equals((T)default))
                yield return cell;
            }
        }
        return CanMakeHole(Cross().ToArray()) ? Brush.GetValue(pos,nearest[1,1]) : nearest[1,1];
    }
}