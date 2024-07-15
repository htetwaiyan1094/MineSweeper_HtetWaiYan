using MineSweeper_HtetWaiYan.Base;
using MineSweeper_HtetWaiYan.Models;

namespace MineSweeper_HtetWaiYan
{
    public class MineSweeperGameApp
    {
        public static void Main()
        {
            var ioHandler = new AppConsole();
            BaseMineSweeperGame game = new ConsoleMineSweeperGame(ioHandler);
            game.Start();
        }
    }
}
