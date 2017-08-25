using System;

namespace Encoder.Output.Decorators
{
    /// <summary>
    /// Decorate output and passes to a nested ITextWriter
    /// Base class for any output decorator
    /// </summary>
    public abstract class OutputDecorator : ITextWriter
    {
        // nested ITexWriter
        // must be not null
        private ITextWriter writer;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="writer">nested writer</param>
        /// <exception cref="ArgumentNullException">if writer parameter is null</exception>
        protected OutputDecorator(ITextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = writer;
        }

        /// <summary>
        /// Decorate and passes to next writer
        /// </summary>
        /// <param name="data">output string, could be null</param>
        public void Write(string data)
        {
            writer.Write(Decorate(data));
        }

        /// <summary>
        /// Function to decorate output string
        /// </summary>
        /// <param name="data">output string, could be null</param>
        /// <returns>decorated output string</returns>
        protected abstract string Decorate(string data);
    }
}
