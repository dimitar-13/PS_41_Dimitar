using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;

namespace WelcomeExtended.Loggers.FileLoggers
{
    public class FileLogger : ILogger
    {
        private string filePath;
        private readonly string name;

        public FileLogger(string name)
        {
            this.name = name;
            filePath = $"../../../logs/{this.name}_log.txt";
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
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"[{logLevel}]");
            stringBuilder.AppendFormat("[{0}]", name);
            stringBuilder.Append(formatter(state, exception));

            WriteToFile(stringBuilder.ToString());
        }

        private void WriteToFile(string message)
        {
            try
            {
                using(var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    var bytes = Encoding.UTF8.GetBytes(message + '\n');
                    fileStream.Write(bytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
