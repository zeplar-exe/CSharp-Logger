using System;

namespace CSharp_Logger
{
    [Flags]
    public enum LogFilter
    {
         None = 1<<0,
         Debug = 1<<1,
         Warning = 1<<2,
         Error = 1<<3,
         Exception = 1<<4
    }

    public static class LogFilterFactory
    {
        public static LogFilter AllTrue()
        {
            return LogFilter.Debug | LogFilter.Warning | LogFilter.Error | LogFilter.Exception;
        }

        public static LogFilter AllFalse()
        {
            return LogFilter.None;
        }
    }
}