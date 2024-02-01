using Microsoft.Extensions.Options;

namespace ExtremeClassified.WebApi.Logging
{
    [ProviderAlias("PortalLogger")]
    public class PortalLoggerProvider : ILoggerProvider
    {
        public readonly PortalLoggerOptions _options;

        public PortalLoggerProvider(IOptions<PortalLoggerOptions> Options)
        {
            _options = Options.Value;

            if (!Directory.Exists(_options.FolderPath))
            {
                Directory.CreateDirectory(_options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new PortalLogger(this);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
