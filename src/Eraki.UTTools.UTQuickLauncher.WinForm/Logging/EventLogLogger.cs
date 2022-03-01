using System.Diagnostics;

namespace Eraki.UTTools.UTQuickLauncher.WinForm.Logging
{
	public class EventLogLogger : LogBase
    {
        private void Log(EventLogEntryType level, string message)
        {
            using (var eventLog = new EventLog("Application"))
            {
                eventLog.Source = "UTQuickLauncherEventLog";
                eventLog.WriteEntry(message, level, 101, 1);
            }
        }

        public override void Error(string message)
        {
            Log(EventLogEntryType.Error, message);
        }

        public override void Info(string message)
        {
            Log(EventLogEntryType.Information, message);
        }
    }
}