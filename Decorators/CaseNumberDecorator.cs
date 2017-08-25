using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoder.Output.Decorators
{
    /// <summary>
    /// Formats output as "Case #{N}: {data}"
    /// </summary>
    public class CaseNumberDecorator : OutputDecorator
    {
        // internal case counter
        // it is incremented by Write methood
        private int caseCounter = 0;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="writer">nested writer. All checks in base class</param>
        public CaseNumberDecorator(ITextWriter writer) : base(writer) { }

        /// <summary>
        ///  Formats output as "Case #{N}: {data}"
        /// </summary>
        /// <param name="data">output string</param>
        /// <returns></returns>
        protected override string Decorate(string data)
        {
            caseCounter++;
            return $"Case #{caseCounter}: {data}";
        }
    }
}
