using System.Text;
using Avro.File;
using Microsoft.ServiceBus.Messaging;

namespace EhAvroParserCs
{
    internal class Parse
    {
        private readonly string _sourceFile;
        private readonly string? _outputFile;

        public Parse(string sourceFile, string? outputFile)
        {
            _sourceFile = sourceFile;
            _outputFile = outputFile;
        }

        public void ParseFile()
        {
            StreamWriter? writer = null;
            
            try
            {
                using var reader = DataFileReader<EventData>.OpenReader(_sourceFile);

                if (_outputFile is not null)
                {
                    Console.WriteLine($"Source file: {_sourceFile}");
                    Console.WriteLine($"Output file: {_outputFile}");
                    
                    writer = new StreamWriter(_outputFile, false);
                    writer.WriteLine("[");
                }
                else
                {
                    Console.WriteLine("[");
                }

                var delimiter = string.Empty;
                while (reader.HasNext())
                {
                    var item = reader.Next();
                    if (item?.Body is not null)
                    {
                        var eventStr = Encoding.UTF8.GetString(item.Body);
                        if (writer is not null)
                        {
                            writer.Write(delimiter);
                            writer.Write(eventStr);
                        }
                        else
                        {
                            Console.Write(delimiter);
                            Console.WriteLine(eventStr);
                        }
                    }
                    if (string.IsNullOrEmpty(delimiter))
                    {
                        delimiter = ",";
                    }
                }
                if (writer is not null)
                {
                    writer.WriteLine("]");
                }
                else
                {
                    Console.WriteLine("]");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                writer?.Close();
            }
        }
    }
}


