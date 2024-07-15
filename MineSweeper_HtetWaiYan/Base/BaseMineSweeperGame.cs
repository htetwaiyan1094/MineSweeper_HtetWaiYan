using MineSweeper_HtetWaiYan.Interfaces;
using MineSweeper_HtetWaiYan.Models;
using MineSweeper_HtetWaiYan.Utils;

namespace MineSweeper_HtetWaiYan.Base
{
    public abstract class BaseMineSweeperGame : IHasGamePlatform
    {
        public bool IsOver { get; set; } = false;
        public Grid<Cell> Grid { get; set; } = new(0, 0);
        public int Mines { get; set; }
        public int GridRows { get; set; }
        public int GridCols { get; set; }
        private List<Cell> AllCells { get; set; } = [];
        public void InitState()
        {
            Grid = new Grid<Cell>(GridCols, GridRows);
            for (int row = 0; row < GridRows; row++)
                for (int col = 0; col < GridCols; col++)
                    Grid[row, col] = new Cell(row, col);

            AllCells = Grid.GetAllCells().ToList();
        }
        public void Start()
        {
            GetGamePlatform().Run();
        }

        public void Initialize()
        {
            InitState();
            PlaceMines();
            UpdateAdjacentMines();
        }

        public void PlaceMines()
        {
            Random random = new();
            int minesPlaced = 0;
            while (minesPlaced < Mines)
            {
                int row = random.Next(GridRows);
                int col = random.Next(GridCols);
                if (!Grid[row, col].IsMine)
                {
                    Grid[row, col].IsMine = true;
                    minesPlaced++;
                }
            }
        }

        public void UpdateAdjacentMines() => AllCells
            .ForEach(cell => cell.AdjacentMines = cell.GetAdjacentCells(this).Count(x => x.IsMine));

        public void RevealCell(int row, int col)
        {
            var cell = Grid[row, col];
            if (cell.IsRevealed || cell.IsMine)
                return;

            cell.IsRevealed = true;
            if (cell.AdjacentMines == 0)
                foreach (var adjacentCell in cell.GetAdjacentCells(this))
                    RevealCell(adjacentCell.X, adjacentCell.Y);
        }

        public Cell PlayerSelectCell(int row, int col)
        {
            RevealCell(row, col);
            var cell = Grid[row, col];
            IsOver = cell.IsMine || IsGameWon;
            return cell;
        }

        public abstract IGamePlatform<BaseMineSweeperGame> GetGamePlatform();

        public bool IsGameWon => AllCells.All(cell => cell.IsMine || cell.IsRevealed);
    }
}
