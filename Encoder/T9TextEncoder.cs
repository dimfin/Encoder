using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone.Encoding
{
    /// <summary>
    /// Encodes input strings to T9 coding (old SMS style) 
    /// </summary>
    public class T9TextEncoder : ITextEncoder
    {
        /// <summary>
        /// internal class to represent one symbold coding
        /// </summary>
        private class Symbol
        {
            // button key as char
            public char Value;
            // number to press the key
            // must be positive
            public int Count;
        }

        // encoding table
        // the key is one of  a-z and space characters
        // value is a sequence of keys to press to input the char
        // Initialized by static constructor
        // must be not null and all values must be not null.
        private static Dictionary<char, Symbol> translationTable;

        /// <summary>
        /// Static constructor
        /// Initializes the translation table
        /// </summary>
        static T9TextEncoder()
        {
            // mobile phone keyboard
            string[] keyboard = { " ", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            // create translation table
            translationTable = keyboard.
                SelectMany((x, i) => x.Select((c, j) => new { Key = c, Button = (char)('0' + i), Count = j + 1 })).
                ToDictionary(x => x.Key, x => new Symbol { Value = x.Button, Count = x.Count });
        }

        /// <summary>
        /// Default condstructor
        /// </summary>
        public T9TextEncoder() { }


        /// <summary>
        /// Encode input string to required format
        /// </summary>
        /// <param name="data">input string. It could be null</param>
        /// <returns></returns>
        public string Encode(string data)
        {
            // doesn't handle null or empty strings
            if(string.IsNullOrEmpty(data))
            {
                return data;
            }

            StringBuilder result = new StringBuilder();

            // set the varaible to the symbol that doesn't exist in the input string
            Symbol previousSymbol = new Symbol { Value = '.', Count = 1 };
            int count = data.Length;

            for(int i=0; i<count; i++)
            {
                // translate symbol
                Symbol currentSymbol = translationTable[data[i]];

                // if previous symbol is coded by the same digit, add a space
                if(currentSymbol.Value ==  previousSymbol.Value)
                {
                    result.Append(' ');
                }

                // add char encoding
                result.Append(currentSymbol.Value, currentSymbol.Count);

                previousSymbol = currentSymbol;
            }

            // convert output to string
            return result.ToString();
        }
    }
}
