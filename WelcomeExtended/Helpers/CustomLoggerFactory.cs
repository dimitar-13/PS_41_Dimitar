using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Helpers
{
    public class CustomLoggerFactory : ILoggerFactory
    {

        private ILoggerProvider loggerProvider;

        public void AddProvider(ILoggerProvider provider)
        {
            loggerProvider = provider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggerProvider.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
