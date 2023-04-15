using CommandLine;
using EhAvroParserCs;

var parser = new Parser(with => with.HelpWriter = Console.Out);
if (args.Length == 0)
{
    parser.ParseArguments<Options>(new[] { "--help" });
    return 1;
}

var result = parser.ParseArguments<Options>(args);

if (result is Parsed<Options> parsed)
{
    var options = parsed.Value;
    if (options is not null)
    {
        if (options.SourceFile is null)
        {
            return 1;
        }

        try
        {
            var parse = new Parse(options.SourceFile, options.OutputFile);
            parse.ParseFile();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            return 1;        
        }
    }
}
else
{
    return 1;
}

return 0;
