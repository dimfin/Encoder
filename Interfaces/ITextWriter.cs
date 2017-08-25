namespace Encoder.Output
{
    /// <summary>
    /// Interface for classes that write output strings
    /// </summary>
    public interface ITextWriter
    {
        /// <summary>
        /// Write output string
        /// </summary>
        /// <param name="data">output string. It could be null</param>
        void Write(string data);
    }
}