using System;

namespace MobilePhone.Output
{
    /// <summary>
    /// Writes output string to console
    /// </summary>
    public class ConsoleTextWriter : ITextWriter
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsoleTextWriter() { }

        /// <summary>
        /// Writes output string to console
        /// </summary>
        /// <param name="data">string to output</param>
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
