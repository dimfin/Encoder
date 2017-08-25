using System;

namespace MobilePhone.Output
{
    /// <summary>
    /// Formats output as "Case #N: data" and passes to a nested ITextWriter
    /// </summary>
    public class CaseNumberDecorator : ITextWriter
    {
        // internal case counter
        // it is incremented by Write methood
        private int caseCounter = 0;

        // nested ITexWriter
        // must be not null
        private ITextWriter writer;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="writer">nested writer</param>
        /// <exception cref="ArgumentNullException">if writer parameter is null</exception>
        public CaseNumberDecorator(ITextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = writer;
        }

        public void Write(string data)
        {
            caseCounter++;
            data = $"Case #{caseCounter}: {data}";
            writer.Write(data);
        }
    }
}
