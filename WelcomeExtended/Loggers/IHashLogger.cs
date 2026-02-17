using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    public interface IHashLogger : ILogger
    {
        void LogByEventID(int eventId);
        void RemoveByEventID(int eventId);
        void PrintAllLogs();
    }
}
