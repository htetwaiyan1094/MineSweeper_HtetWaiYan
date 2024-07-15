namespace MineSweeper_HtetWaiYan.Interfaces
{
    public interface IGamePlatform<T>
    {
        void Run();
        void BeforeInit();
        void AfterInit();
    }
}
