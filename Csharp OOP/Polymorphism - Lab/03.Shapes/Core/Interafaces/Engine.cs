using Shapes.IO.Interfaces;

namespace Shapes.Core.Interafaces
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

        }
    }
}
