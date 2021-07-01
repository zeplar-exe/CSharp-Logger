namespace CSharp_Logger
{
    public class CatchLogEvent
    {
        public readonly LogFilter LogType;
        public readonly string Content;
        
        public CatchLogEvent(LogFilter logType, string content)
        {
            LogType = logType;
            Content = content;
        }
    }
}