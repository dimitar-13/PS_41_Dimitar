using System.Text;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging; 

namespace WelcomeExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> logMessages;
        private readonly string name;

        public HashLogger(string name)
        {
            this.name = name;   
            logMessages = new ConcurrentDictionary<int, string>();  
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = formatter(state,exception);

            
            switch (logLevel)
            {
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }


            Console.WriteLine("- LOGGER -");
                var messageBuilder = new StringBuilder();
                messageBuilder.Append($"[{logLevel}]");
                messageBuilder.AppendFormat("[{0}]", name);
                Console.WriteLine(message);
                Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");

            Console.ResetColor();
            logMessages[eventId.Id] = message;
        }
    }
}
