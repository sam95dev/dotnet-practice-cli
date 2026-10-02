using System.CommandLine;
using System.CommandLine.Parsing;
using App.Option;
using App.Service;

namespace App;

partial class Program
{
    static int Main(string[] args)
    {
        // Build file option and max read lines option
        var fileOption = CommonOption.NewFileOption();
        var maxReadLines = CommonOption.NewMaxReadLinesOption();
        var helpOption = CommonOption.NewHelpOption();

        // Build root command
        RootCommand rootCommand = new("Sampl app for System.CommandLine");
        rootCommand.Options.Add(fileOption);
        rootCommand.Options.Add(maxReadLines);
        rootCommand.Options.Add(helpOption);

        // Parse command line arguments
        ParseResult parseResult = rootCommand.Parse(args);

        // First check if have errors
        if (parseResult.Errors.Count > 0)
        {
            Console.WriteLine("Parsing errors:");
            Console.WriteLine(new string('-', Convert.ToInt16(Console.BufferWidth * 0.7f)));
            // Display parsing errors
            foreach (ParseError parseError in parseResult.Errors)
            {
                Console.Error.WriteLine(parseError.Message);
            }

            // Return non-zero exit code to indicate errors
            return 1;
        }

        // Check if --help option was passed and display help
        if (parseResult.Tokens.Any(t => t.Value == CommonOption.HelpFlag))
        {
            Console.WriteLine("Program Help");
            Console.WriteLine("Usage: dotnet run -- --file <path> [--max-read-lines <count>]");
            Console.WriteLine("For help: dotnet run -- ... --help, shows this help message");
            return 0;
        }

        // Check if the file option was provided and is a valid file
        if (parseResult.GetValue(fileOption) is FileInfo parsedFile)
        {
            Console.WriteLine($"Reading file: {parsedFile.FullName}");
            Console.WriteLine(new string('-', Convert.ToInt16(Console.BufferWidth * 0.7f)));
            CommonService.ReadFile(parsedFile, parseResult.GetValue(maxReadLines));
        }

        return 0;
    }
}
