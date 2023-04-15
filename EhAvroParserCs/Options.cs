using CommandLine;

namespace EhAvroParserCs
{
    internal class Options
    {
        [Option('s', "source", Required = true, HelpText = "Source file to be processed.")]
        public string? SourceFile { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file to be created.")]
        public string? OutputFile { get; set; }
    }
}
