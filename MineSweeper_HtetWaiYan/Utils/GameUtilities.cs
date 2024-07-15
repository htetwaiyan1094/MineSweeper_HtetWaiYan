using MineSweeper_HtetWaiYan.Base;
using MineSweeper_HtetWaiYan.Enums;
using MineSweeper_HtetWaiYan.Models;

namespace MineSweeper_HtetWaiYan.Utils
{
    public static class GameUtilities
    {
        private static readonly Dictionary<Direction, (int, int)> AllDirections = new()
        {
            { Direction.Up, (0, -1) },
            { Direction.Down, (0, 1) },
            { Direction.Left, (-1, 0) },
            { Direction.Right, (1, 0) },
            { Direction.UpLeft, (-1, -1) },
            { Direction.UpRight, (1, -1) },
            { Direction.DownLeft, (-1, 1) },
            { Direction.DownRight, (1, 1) }
        };

        public static Cell? GetAdjacentCell(this Cell cell, BaseMineSweeperGame game, Direction direction)
        {
            var (dy, dx) = AllDirections[direction];
            var targetX = cell.X + dx;
            var targetY = cell.Y + dy;
            if (targetX < 0 || targetX >= game.GridRows || targetY < 0 || targetY >= game.GridCols)
                return null;
            return game.Grid[targetX, targetY];
        }

        public static IEnumerable<Cell> GetAdjacentCells(this Cell cell, BaseMineSweeperGame game)
        {
            foreach (var direction in AllDirections.Keys.AsEnumerable())
            {
                Cell? adjacentCell = cell.GetAdjacentCell(game, direction);
                if (adjacentCell != null)
                    yield return adjacentCell;
            }
        }
    }
}
