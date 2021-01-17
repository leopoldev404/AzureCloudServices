using System;
using static AzureCloudServices.Bll.Services.Logging.LoggingEventTypeEnum;

namespace AzureCloudServices.Bll.Services.Logging
{
	public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message == string.Empty) throw new ArgumentException("empty", message);

            Severity = severity;
            Message = message;
            Exception = exception;
        }
    }
}
