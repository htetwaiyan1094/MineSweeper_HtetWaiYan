using MineSweeper_HtetWaiYan.Base;
using MineSweeper_HtetWaiYan.Interfaces;
using MineSweeper_HtetWaiYan.Models;

namespace MineSweeper_HtetWaiYan
{
    public class ConsoleMineSweeperGame : BaseMineSweeperGame
    {
        private ConsolePlatform _platform;

        public ConsoleMineSweeperGame(IInputOutputHandler ioHandler)
        {
            _platform = new ConsolePlatform(this, ioHandler);
        }

        public override IGamePlatform<BaseMineSweeperGame> GetGamePlatform() => _platform;
    }
}
