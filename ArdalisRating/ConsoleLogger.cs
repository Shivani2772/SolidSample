using System;

namespace ArdalisRating
{
    /// <summary>
    /// This follows ISP
    /// </summary>
    public interface ILogger
    {
        void Log(String message);
    }
    /// <summary>
    /// This follow the SRP logging behaviour
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}