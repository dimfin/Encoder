using System;
using System.Collections.Generic;

namespace Encoder.Input
{

    /// <summary>
    /// Reads data from console in format:
    /// 1st string: number of strings
    /// 2 .. N: some input strings
    /// </summary>
    public class ConsoleTextReader : ITextReader
    {
        // default readData fumction
        private Func<string> readData;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="readDataFunction">function to get a chunk of data</param>
        /// <exception cref="ArgumentNullException">if readDataFuction is null</exception> 
        public ConsoleTextReader(Func<string> readDataFunction)
        {
            if(readDataFunction == null)
            {
                throw new ArgumentNullException("readDataFunction");
            }

            readData = readDataFunction;
        }

        /// <summary>
        /// Default constructor 
        /// Uses default readData function
        /// </summary>
        public ConsoleTextReader()
        {
            readData = () => Console.ReadLine();
        }

        /// <summary>
        /// Reads data from console in format:
        /// 1st string: number of strings
        /// 2 .. N: some input strings
        /// </summary>
        /// <returns>Input strings</returns>
        /// <exception cref="ArgumentNullException">if the first string is null</exception>
        /// <exception cref="FormatException">if the first string is not a number</exception>
        /// <exception cref="FormatException">if the first string is zero or negative integer</exception>
        /// <exception cref="OverflowException">if the first string is out of integer range</exception>
        public IEnumerable<string> Read()
        {
            // read number of strings
            string countString = readData();

            // try to parse
            // if it can't let an exception throw 
            int count = int.Parse(countString);

            // check that number of string is positive integer
            if (count < 1)
            {
                throw new FormatException("The first input string must be a positive integer");
            }

            // enumerate input strings
            for (int i = 0; i < count; i++)
            {
                yield return readData();
            }
        }
    }
}
