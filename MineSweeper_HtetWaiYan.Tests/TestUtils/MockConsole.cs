using MineSweeper_HtetWaiYan.Interfaces;
using System.Text;

namespace MineSweeper_HtetWaiYan.Tests.TestUtils
{
    public class MockConsole : IInputOutputHandler
    {
        readonly Queue<string> _input;
        readonly StringBuilder _output = new();
        public MockConsole(IEnumerable<string> input)
        {
            _input = new Queue<string>(input);
        }
        public string ReadLine() => _input.Dequeue();

        public void Write(string message) => _output.Append(message);

        public void WriteLine(string message) => _output.AppendLine(message);

        public string Outputs => _output.ToString();
        public void AddInput(string input) => _input.Enqueue(input);
    }
}
