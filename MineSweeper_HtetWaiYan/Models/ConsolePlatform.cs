using MineSweeper_HtetWaiYan.Base;
using MineSweeper_HtetWaiYan.Interfaces;

namespace MineSweeper_HtetWaiYan.Models
{
    public class ConsolePlatform : IGamePlatform<BaseMineSweeperGame>
    {
        static readonly string chars = "ABCDEFGHIJ"; // only 10 chars based on game max grid size.
        private readonly BaseMineSweeperGame _game;

        private readonly IInputOutputHandler _ioHandler;

        public ConsolePlatform(BaseMineSweeperGame game, IInputOutputHandler ioHandler)
        {
            _game = game;
            _ioHandler = ioHandler;
        }

        private void ShowCurrentState()
        {
            _ioHandler.WriteLine($"{Environment.NewLine}Here is your minefield:");
            _ioHandler.Write("  ");
            _ioHandler.WriteLine(string.Join(" ", Enumerable.Range(0, _game.Grid.Rows).Select(row => row + 1)));
            for (int row = 0; row < _game.GridRows; row++)
            {
                var values = Enumerable.Range(0, _game.Grid.Cols)
                    .Select(col =>
                    {
                        var cell = _game.Grid[row, col];
                        return cell.IsRevealed ? $"{cell.AdjacentMines}" : "_";
                    });
                var line = $"{chars[row]} {string.Join(" ", values)}";
                _ioHandler.WriteLine($"{line}");
            }
        }

        private int PromptSize()
        {
            int size, minSize = 3, maxSize = 10;
            bool validSize = false;
            string sizeError = string.Empty;
            do
            {
                // prompt size value until the input is valid
                _ioHandler.WriteLine();
                _ioHandler.WriteLine("Enter the size of the grid (e.g. 4 for a 4x4 grid):");
                if (!string.IsNullOrEmpty(sizeError)) _ioHandler.WriteLine(sizeError);

                if (!int.TryParse(_ioHandler.ReadLine(), out size)) sizeError = "Incorect input.";
                else if (size < minSize) sizeError = "Minimum size of grid is 2.";
                else if (size > maxSize) sizeError = "Maximum size of grid is 10.";
                else validSize = true;
            } while (!validSize);
            return size;
        }

        public int PromptMines(int size)
        {
            int mines, minMines = 1, maxMines = Convert.ToInt16(Math.Floor((size * size * 35) / 100d));
            bool validMines = false;
            string minesError = string.Empty;
            do
            {
                // prompt no of mines value until the input is valid
                _ioHandler.WriteLine();
                _ioHandler.WriteLine("Enter the number of mines to place on the grid (maximum is 35% of the total squares):");
                if (!string.IsNullOrEmpty(minesError)) _ioHandler.WriteLine(minesError);

                if (!int.TryParse(_ioHandler.ReadLine(), out mines)) minesError = "Incorect input.";
                else if (mines < minMines) minesError = "There must be at least 1 mine.";
                else if (mines > maxMines) minesError = "Maximum number is 35% of total sqaures.";
                else validMines = true;
            } while (!validMines);
            return mines;
        }

        public (int, int) PromptSquare(int size)
        {
            int x = -1, y = -1;
            bool validSquare = false;
            do
            {
                // prompt square value until the input is valid
                _ioHandler.WriteLine();
                _ioHandler.Write("Select a square to reveal (e.g. A1): ");

                string? squareInput = _ioHandler.ReadLine();
                if (!string.IsNullOrEmpty(squareInput) && new[] { 2, 3 }.Contains(squareInput.Length))
                {
                    x = chars.IndexOf(squareInput.ElementAt(0));
                    if (int.TryParse(squareInput.AsSpan(1), out y))
                    {
                        y -= 1;
                        if (x >= 0 && x < size && y >= 0 && y < size)
                            validSquare = true;
                    }
                }
                if (!validSquare) _ioHandler.WriteLine("Incorrect input.");
            } while (!validSquare);
            return (x, y);
        }

        public void Run()
        {
            BeforeInit();
            _game.Initialize();
            AfterInit();
        }

        public void BeforeInit()
        {
            _ioHandler.WriteLine($"Welcome to Minesweeper!");

            int size = PromptSize();
            _game.GridRows = size;
            _game.GridCols = size;

            int mines = PromptMines(size);
            _game.Mines = mines;
        }

        public void AfterInit()
        {
            do
            {
                ShowCurrentState();
                var (x, y) = PromptSquare(_game.GridRows);
                var cell = _game.PlayerSelectCell(x, y);

                if (!_game.IsOver)
                    _ioHandler.WriteLine($"This square contains {cell.AdjacentMines} adjacent mines.");
            } while (!_game.IsOver);

            if (_game.IsGameWon)
                ShowCurrentState();

            _ioHandler.WriteLine(_game.IsGameWon
                ? "Congratulations, you have won the game!"
                : "Oh no, you detonated a mine! Game over.");
        }
    }
}
