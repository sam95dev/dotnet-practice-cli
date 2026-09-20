using System.CommandLine;
using System.CommandLine.Parsing;

namespace scl;

partial class Program
{
	static int Main(string[] args)
	{
		Option<FileInfo> fileOption = new("--file")
		{
			Description = "The file to r3ad and display on the console"
		};

		RootCommand rootCommand = new("Sampl app for System.CommandLine");
		rootCommand.Options.Add(fileOption);

		ParseResult parseResult = rootCommand.Parse(args);
		if (parseResult.Errors.Count == 0 && parseResult.GetValue(fileOption) is FileInfo parsedFile)
		{
			ReadFile(parsedFile);
			return 0;
		}

		foreach(ParseError parseError in parseResult.Errors)
		{
			Console.Error.WriteLine(parseError.Message);
		}

		return 1;
	}

	static void ReadFile(FileInfo file)
	{
		foreach(string line in File.ReadLines(file.FullName))
		{
			Console.WriteLine(line);
		}
	}
}
