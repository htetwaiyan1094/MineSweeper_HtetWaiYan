using MineSweeper_HtetWaiYan.Models;

namespace MineSweeper_HtetWaiYan.Tests.UnitTests
{
    [TestClass]
    public class GameGeneralTests
    {
        [TestMethod]
        public void GameInit_SizeMines_ReturnCorrectGameState()
        {
            // Arrange
            var size = 5;
            var mines = 3;
            var game = new ConsoleMineSweeperGame(new AppConsole())
            {
                GridRows = size,
                GridCols = size,
                Mines = mines
            };

            // Act
            game.Initialize();

            // Assert
            var allCells = game.Grid.GetAllCells();
            Assert.AreEqual(size * size, allCells.Count());
            Assert.AreEqual(mines, allCells.Count(c => c.IsMine));
        }
    }
}
