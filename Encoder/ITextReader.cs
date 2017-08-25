using System.Collections.Generic;

namespace MobilePhone.Input
{
    /// <summary>
    /// Interace for classes that read input strings
    /// </summary>
    public interface ITextReader
    {
        /// <summary>
        /// Enumerates input strings
        /// </summary>
        /// <returns>input strings</returns>
        IEnumerable<string> Read();
    }
}