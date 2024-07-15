using MineSweeper_HtetWaiYan.Base;

namespace MineSweeper_HtetWaiYan.Interfaces
{
    public interface IHasGamePlatform
    {
        IGamePlatform<BaseMineSweeperGame> GetGamePlatform();
    }
}
