namespace MobilePhone.Encoding
{
    /// <summary>
    /// Interface for classes that encode the input string to output one
    /// </summary>
    public interface ITextEncoder
    {
        /// <summary>
        /// Encode data string to target one
        /// </summary>
        /// <param name="data">input string. It could be null</param>
        /// <returns>output string</returns>
        string Encode(string data);
    }
}