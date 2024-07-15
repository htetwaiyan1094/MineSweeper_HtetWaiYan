using MineSweeper_HtetWaiYan.Enums;
using MineSweeper_HtetWaiYan.Models;
using MineSweeper_HtetWaiYan.Utils;

namespace MineSweeper_HtetWaiYan.Tests.UnitTests
{
    [TestClass]
    public class UtilityTests
    {
        readonly string _basePath = $"{nameof(UnitTests)}/{nameof(UtilityTests)}";

        [TestMethod]
        public void GetAdjacentCell_AllDirectionsOfX1Y1_ReturnsCorrectCells()
        {
            // Arrange
            var expected = new Dictionary<Direction, (int, int)>
            {
                { Direction.UpLeft, (0, 0) },
                { Direction.Up, (0, 1) },
                { Direction.UpRight, (0, 2) },
                { Direction.Left, (1, 0) },
                { Direction.Right, (1, 2) },
                { Direction.DownLeft, (2, 0) },
                { Direction.Down, (2, 1) },
                { Direction.DownRight, (2, 2) }
            };
            var game = new ConsoleMineSweeperGame(new AppConsole()) { GridCols = 3, GridRows = 3 };
            game.InitState();

            foreach (var kvp in expected)
            {
                // Act
                var cell = game.Grid[1, 1].GetAdjacentCell(game, kvp.Key);

                // Assert
                var (expectedX, expecetedY) = kvp.Value;
                Assert.IsNotNull(cell);
                Assert.AreEqual(cell.X, expectedX);
                Assert.AreEqual(cell.Y, expecetedY);
            }
        }

    }
}