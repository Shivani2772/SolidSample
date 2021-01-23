using System;

namespace ArdalisRating
{
    /// <summary>
    /// This follow the SRP logging behaviour
    /// </summary>
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}