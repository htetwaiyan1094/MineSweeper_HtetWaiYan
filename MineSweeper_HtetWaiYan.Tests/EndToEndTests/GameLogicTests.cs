using MineSweeper_HtetWaiYan.Models;
using MineSweeper_HtetWaiYan.Tests.TestUtils;

namespace MineSweeper_HtetWaiYan.Tests.EndToEndTests
{
    [TestClass]
    public class GameLogicTests
    {
        static readonly string chars = "ABCDEFGHIJ";
        readonly string _basePath = nameof(EndToEndTests);

        [TestMethod]
        public void Game_UserWon_ReturnsCongratulations()
        {
            // Arrange
            var inputFile = $"{_basePath}/TestCases/EndToEndTest_GameInit_Inputs.txt";
            var inputs = File.ReadAllLines(inputFile);
            var size = inputs.ElementAt(0);
            var mines = inputs.ElementAt(1);

            var mock = new MockConsole(inputs);
            var game = new ConsoleMineSweeperGame(mock);

            // Act: get all safe cells and add into mock inputs
            game.GetGamePlatform().BeforeInit();
            game.Initialize();

            var cells = game.Grid.GetAllCells();
            foreach (var cell in cells.Where(c => !c.IsMine))
                mock.AddInput($"{chars.ElementAt(cell.X)}{cell.Y + 1}");

            game.GetGamePlatform().AfterInit();

            // Assert
            var outputs = mock.Outputs;
            Assert.IsTrue(outputs.Trim().EndsWith("Congratulations, you have won the game!"));
        }

        [TestMethod]
        public void Game_GameOver_ReturnsGameOver()
        {
            // Arrange
            var inputFile = $"{_basePath}/TestCases/EndToEndTest_GameInit_Inputs.txt";
            var inputs = File.ReadAllLines(inputFile);
            var size = inputs.ElementAt(0);
            var mines = inputs.ElementAt(1);

            var mock = new MockConsole(inputs);
            var game = new ConsoleMineSweeperGame(mock);

            // Act: get mine cell and add into mock inputs.
            game.GetGamePlatform().BeforeInit();
            game.Initialize();
            var cells = game.Grid.GetAllCells();
            var cell = cells.First(c => c.IsMine);
            mock.AddInput($"{chars.ElementAt(cell.X)}{cell.Y + 1}");
            game.GetGamePlatform().AfterInit();

            // Assert
            var outputs = mock.Outputs;
            Assert.IsTrue(outputs.Trim().EndsWith("Oh no, you detonated a mine! Game over."));
        }
    }
}
