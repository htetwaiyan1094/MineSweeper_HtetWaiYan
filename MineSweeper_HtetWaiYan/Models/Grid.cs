namespace MineSweeper_HtetWaiYan.Models
{
    public class Grid<T>
    {
        protected T[,] grid;
        public int Rows => grid.GetLength(0);
        public int Cols => grid.GetLength(1);

        public Grid(int rows, int columns)
        {
            grid = new T[rows, columns];
        }

        public T this[int row, int column]
        {
            get { return grid[row, column]; }
            set { grid[row, column] = value; }
        }

        public IEnumerable<T> GetAllCells()
        {
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    yield return grid[row, col];
        }
    }
}
