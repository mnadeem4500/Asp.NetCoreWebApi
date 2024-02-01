using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ExtremeClassified.WebApi.Logging
{
    internal class PortalLogger : ILogger
    {
        protected readonly PortalLoggerProvider _logProvider;

        public PortalLogger([NotNull] PortalLoggerProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
            // throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.None)
                return false;
            return true;
            //throw new NotImplementedException();
        }

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //throw new NotImplementedException();
            if (!IsEnabled(logLevel))
                return;

            var date = DateTime.UtcNow;
            var filePath = string.Format("{0}/{1}", _logProvider._options.FolderPath, _logProvider._options.FilePath.Replace("{date}", date.ToString("dd_MMMM_yyyy")));

            var logReord = string.Format("{0} [{1}] {2} {3}", date.ToString("dd-MMMM-yyyy hh:mm:ss"), logLevel.ToString(),
                formatter(state, exception), (exception != null ? exception.StackTrace : ""));

            using (var streamWriter = new StreamWriter(filePath, true))
            {
                await streamWriter.WriteLineAsync(logReord);
            }
        }
    }
}