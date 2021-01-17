using System;
using static AzureCloudServices.Bll.Services.Logging.LoggingEventTypeEnum;

namespace AzureCloudServices.Bll.Services.Logging
{
	public static class ILoggerExtension
    {
        public static void Log(this ILogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, message));
        }

        public static void Log(this ILogger logger, Exception ex)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, ex.Message, ex));
        }
    }
}
