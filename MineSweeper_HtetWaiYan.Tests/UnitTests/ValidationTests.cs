using MineSweeper_HtetWaiYan.Models;
using MineSweeper_HtetWaiYan.Tests.TestUtils;

namespace MineSweeper_HtetWaiYan.Tests.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        readonly string _basePath = nameof(UnitTests);

        [TestMethod]
        public void Game_ValidationFailure_ReturnsCorrectError()
        {
            // Arrange
            var fileName = $"{_basePath}/TestCases/{nameof(ValidationTests)}_{nameof(Game_ValidationFailure_ReturnsCorrectError)}";
            var inputFile = $"{fileName}_In.txt";
            var outpufFile = $"{fileName}_Out.txt";

            var inputs = File.ReadAllLines(inputFile);
            var expected = File.ReadAllText(outpufFile);

            var mock = new MockConsole(inputs);
            var game = new ConsoleMineSweeperGame(mock);

            // Act
            game.Start();

            // Assert
            var outputs = mock.Outputs;
            Assert.IsTrue(outputs.StartsWith(expected));
        }
    }
}