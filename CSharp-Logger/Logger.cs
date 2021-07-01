using System.IO;

namespace CSharp_Logger
{
    public partial class Logger
    {
        private FileInfo logFile;
        private LogFilter filter;

        public void SetConfiguration(string logFilePath, LogFilter logFilter)
        {
            logFile = ValidateFilePath(logFilePath);
            filter = logFilter;
        }
        
        public void SetConfiguration(string logFilePath)
        {
            //logFile = new FileInfo(logFilePath);
            logFile = ValidateFilePath(logFilePath);
            filter = LogFilterFactory.AllTrue();
        }

        public delegate void CatchLogEventHandler(Logger logger, CatchLogEvent args);

        public event CatchLogEventHandler CatchLog;

        public static FileInfo ValidateFilePath(string input)
        {
            const string logFileExtension = ".log";
            const string defaultLogFile = "cs-log" + logFileExtension;

            if (Directory.Exists(input))
            {
                string defaultFilePath = Path.Join(input, defaultLogFile);

                File.Create(defaultFilePath);
                return new FileInfo(defaultFilePath);
            }
            
            if (File.Exists(input))
            {
                var fileInfo = new FileInfo(input);

                if (fileInfo.Extension == logFileExtension)
                    return fileInfo;
            }

            throw new InvalidLogFileException("The given log file (or directory) is not valid.");
        }
    }
}