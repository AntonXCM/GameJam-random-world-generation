public enum Direction
{
    Right = 0b_1000_0000, Left = 0b_1100_0000, Down = 0b_0011_0000, Up = 0b_0010_0000
}
public enum ActionStopMode
{
    None, StopCycle, AddRowToIgnoreList, StopIterating
}
public abstract class GridIterator<T> : IteratorGenerationModule<T>
{
    protected ActionStopMode actionStopMode;
    protected Direction direction = Direction.Right;
    protected override void Iterate() => Iterate(new());
    protected void Iterate(List<int> ignoreList)
    {
        try
        {
        switch (direction)
        {
            case Direction.Up:
            for(int i = 0; i < rows; i++)
                for(int j = cols - 1; j >= 0; j--)
                    if(ifCondition(i,j,true))
                        StopIterating(ref j);
            break;
            case Direction.Left:
            for(int j = 0; j < cols; j++)
                for(int i = rows - 1; i >= 0; i--)
                     if (ifCondition(i, j, false))
                        StopIterating(ref i);
                break;
            case Direction.Down:
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (ifCondition(i, j, true))
                            StopIterating(ref j);
            break;
            case Direction.Right:
                for (int j = 0; j < cols; j++)
                    for (int i = 0; i < rows; i++)
                        if (ifCondition(i, j, false))
                            StopIterating(ref i);
            break;
        }
        }
        catch(Exception ex)
        {
            if(ex.GetType() == typeof(OperationCanceledException))
            return;
            throw;
        }
        bool ifCondition(int i, int j, bool isHorisontal) => !ignoreList.Contains(isHorisontal ? j : i) && Action(new(i, j)) == true;

        void StopIterating(ref int i)
        {
            switch (actionStopMode)
            {
                case ActionStopMode.StopCycle:
                    i = -1;
                    break;
                case ActionStopMode.AddRowToIgnoreList:
                    ignoreList.Add(i);
                    break;
                case ActionStopMode.StopIterating:
                    throw new OperationCanceledException();
            }
        }
    }
}