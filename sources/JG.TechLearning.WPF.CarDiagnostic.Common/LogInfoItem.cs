using JG.TechLearning.WPF.CarDiagnostic.Common.Enums;
using System;

namespace JG.TechLearning.WPF.CarDiagnostic.Common
{
    public class LogInfoItem
    {
        private DateTime timeStamp = DateTime.Now;
        private String message = string.Empty;
        private LogInfoSeverity severity = Enums.LogInfoSeverity.Unknown;

        public LogInfoSeverity Severity
        {
            get
            {
                return severity;
            }
        }

        public string Timestamp
        {
            get
            {
                return timeStamp.ToString("HH:mm:ss");
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public string TimeStampAndMessage
        {
            get
            {
                return $"{DateTime.Now.ToString("HH:mm:ss")}: {Message}";
            }
        }

        public LogInfoItem(string message, LogInfoSeverity severity = LogInfoSeverity.Unknown)
        {
            this.message = message;
            this.severity = severity;
        }

    }
}
