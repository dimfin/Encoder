using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Encoder.Encoding;
using Encoder.Input;
using Encoder.Output;
using System;

namespace Encoder
{
    /// <summary>
    /// Start point of the program
    /// </summary>
    public class Program
    {
        // input data reader
        // must be not null
        private ITextReader reader;

        // encoder of input strings
        // must be not null
        private ITextWriter writer;

        // writer of output strings
        // must be not nukk
        private ITextEncoder encoder;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="reader">input data reader</param>
        /// <param name="encoder">encoder of input strings</param>
        /// <param name="writer">writer of output strings</param>
        /// <exception cref="ArgumentNullException">if reader is null</exception>
        /// <exception cref="ArgumentNullException">if encoder is null</exception>
        /// <exception cref="ArgumentNullException">if writer is null</exception>
        public Program(ITextReader reader, ITextEncoder encoder, ITextWriter writer)
        {
            if(reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            this.reader = reader;
            this.encoder = encoder;
            this.writer = writer;
        }

        /// <summary>
        /// Default constructor
        /// Uses reader, encoder and writer defined in app.config file
        /// </summary>
        public Program()
        {
            try
            {
                var container = new WindsorContainer(new XmlInterpreter());

                reader = container.Resolve<ITextReader>();
                encoder = container.Resolve<ITextEncoder>();
                writer = container.Resolve<ITextWriter>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Configuration error:\r\n{0}", e.Message);
            }
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            string result;

            // for each string that is read
            try
            {
                foreach (string inputString in reader.Read())
                {
                    try
                    {
                        // encode input string
                        result = encoder.Encode(inputString);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Encoding error\r\n{0}", e.Message);
                        break;
                    }

                    try
                    {
                        // write to output
                        writer.Write(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Data output error\r\n{0}", e.Message);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Data input error\r\n{0}", e.Message);
            }
        }

        static void Main(string[] args)
        {
            // get a Program instance
            Program p = new Program();

            // run it
            p.Run();
        }
    }
}
