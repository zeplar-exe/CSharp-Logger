using System;
using System.IO;
using System.Text;

namespace CSharp_Logger
{
    public partial class Logger
    {
        public void Debug(string message)
        {
            WriteToLogFile(LogFilter.Debug, message);
        }

        public void Warn(string message)
        {
            WriteToLogFile(LogFilter.Warning, message);
        }

        public void Error(string message)
        {
            WriteToLogFile(LogFilter.Error, message);
        }

        public void Exception(Exception exception)
        {
            WriteToLogFile(LogFilter.Exception, exception.ToString());
        }

        private void InvokeCatchLogEvent(LogFilter logFilter, string message)
        {
            CatchLog?.Invoke(this, new CatchLogEvent(logFilter, message));
        }

        private void WriteToLogFile(LogFilter type, string message)
        {
            if (!WriterEnabled(type))
                return;
            
            if (logFile == null)
                throw new InvalidLogFileException("Log file must be set before attempting to write.");
            
            var log = new StringBuilder();

            log.AppendLine();
            log.AppendLine($"{type.ToString().ToUpper()} at {DateTime.Now.ToLongDateString()} | {DateTime.Now.ToLongTimeString()}");
            
            log.AppendLine("----------------");
            log.AppendLine(message);
            log.AppendLine("----------------");
            
            log.AppendLine();

            var writer = new FileStream(logFile.FullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            
            writer.Write(Encoding.Unicode.GetBytes(log.ToString()));
            writer.Close();
                
            InvokeCatchLogEvent(type, message);
        }
        
        private bool WriterEnabled(LogFilter debug)
        {
            return filter.HasFlag(debug);
        }
    }
}