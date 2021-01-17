using AzureCloudServices.Bll.Services.Logging;
using Serilog.Events;

namespace AzureCloudServices.WebApi.Installer
{
	public class SerilogLoggerWrapper : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLoggerWrapper(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public void Log(LogEntry entry)
        {
            _logger.Write((LogEventLevel)entry.Severity, entry.Exception, entry.Message);
        }
    }
}
