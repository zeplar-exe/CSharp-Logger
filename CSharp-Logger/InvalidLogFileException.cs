using System;

namespace CSharp_Logger
{
    public class InvalidLogFileException : Exception
    {
        public InvalidLogFileException(string message) : base(message) { }
    }
}