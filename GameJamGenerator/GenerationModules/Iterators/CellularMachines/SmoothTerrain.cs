public class SmoothTerrain<T> : CellularMachine<T>
{
    private readonly AroundGrid aroundCheckerGrid;

    public SmoothTerrain(AroundGrid grid)
    {
        aroundCheckerGrid = grid;
    }

    public struct AroundGrid
    {
        public bool[,] Grid;
        public static readonly bool[,] DefaultEight = { { true, true, true }, { true, false, true }, { true, true, true } };

        public AroundGrid(bool[,] grid)
        {
            Grid = grid;
            rows = grid.GetLength(0) - 1;
            cols = grid.GetLength(1) - 1;
        }

        private readonly int rows, cols;
        private int _pointsInGrid;

        public int PointsInGrid
        {
            get
            {
                if(_pointsInGrid != 0) return _pointsInGrid;

                int trueCount = 0;
                for(int i = rows; i > 0; i--)
                    for(int j = cols; j > 0; j--)
                        if(Grid[i, j]) trueCount++;

                _pointsInGrid = trueCount;
                return trueCount;
            }
        }

        public bool AverangeStateCheck(IGrid<T> grid, Vector2Int pos)
        {
            int trueCount = 0;
            for(int i = rows; i > 0; i--)
                for(int j = cols; j > 0; j--)
                    try
                    {
                        if(grid[(i - rows / 2) + pos.x, (j - cols / 2) + pos.y]) trueCount++;
                    }
                    catch
                    {
                        return true;
                    }
            return trueCount > PointsInGrid / 2;
        }
    }
    protected override void Action(int i, int j)
    {
        grid[i, j] = aroundCheckerGrid.AverangeStateCheck(inputGrid, new(i, j));
    }
}