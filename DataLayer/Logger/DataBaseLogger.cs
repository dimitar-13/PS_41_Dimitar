using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Welcome.Model;

namespace DataLayer.Logger
{
    public class DataBaseLogger : ILogger
    {
        private ConcurrentDictionary<int, DatabaseUserLog> logs;

        private readonly string name;
        public DataBaseLogger(string categoryName)
        {
            name = categoryName;

            logs = new ConcurrentDictionary<int, DatabaseUserLog>();

            using(var context = new DatabaseContext())
            {
                var existingLogs = context.UserLogs.ToList();
                foreach (var log in existingLogs)
                {
                    logs.TryAdd(log.Id, log);
                }
            }
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
            try
            {
                var newLog = new DatabaseUserLog
                {
                    LogMessage = formatter(state, exception)
                };

                using (var context = new DatabaseContext())
                {
                    context.UserLogs.Add(newLog);
                    context.SaveChanges();
                    logs.TryAdd(newLog.Id, newLog);
                }
            }
            catch (Exception ex)
            {
               throw new Exception("Failed to log message to database", ex);
            }
        }
    }
}
