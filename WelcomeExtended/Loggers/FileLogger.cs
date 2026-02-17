using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Text;

namespace WelcomeExtended.Loggers
{
    public class FileLogger : ILogger
    {
        private static string FILE_PATH = "../../../logs/log.txt";
        private readonly string name;

        public FileLogger(string name)
        {
            this.name = name;
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

            this.WriteToFile(stringBuilder.ToString());
        }

        private void WriteToFile(string message)
        {
            try
            {
                using(var fileStream = new FileStream(FileLogger.FILE_PATH, FileMode.Create, FileAccess.Write))
                {
                    var bytes = Encoding.UTF8.GetBytes(message);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
