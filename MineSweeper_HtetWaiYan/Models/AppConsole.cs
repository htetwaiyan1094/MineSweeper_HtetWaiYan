using MineSweeper_HtetWaiYan.Interfaces;

namespace MineSweeper_HtetWaiYan.Models
{
    public class AppConsole : IInputOutputHandler
    {
        public string ReadLine() => Console.ReadLine() ?? string.Empty;
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
    }
}
