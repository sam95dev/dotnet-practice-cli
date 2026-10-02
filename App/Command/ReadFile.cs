using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using App.Settings;
using App.Service;

namespace App.Command;

internal class ReadFileCommand : Command<ReadFileCommand.Settings>
{
    public class Settings : GlobalSettings
    {
        [CommandArgument(0, "<file>")]
        [Description("The file to read")]
        public required string FilePath { get; init; }

        [CommandOption("-m|--max-read-lines")]
        [Description("The maximum number of lines to read")]
        public int MaxReadLines { get; init; } = 0;
    }

    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        if (settings.MaxReadLines < 0)
        {
            AnsiConsole.MarkupLine("[red]Max read lines must be a non-negative integer[/]");
            return 1;
        }

        if (settings.MaxReadLines == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No max read lines specified, reading all lines[/]");
        }

        var fileInfo = new FileInfo(settings.FilePath);
        if (!fileInfo.Exists)
        {
            AnsiConsole.MarkupLine($"[red]File not found: {fileInfo.FullName}[/]");
            return 1;
        }

        AnsiConsole.MarkupLine($"[green]Reading file: {fileInfo.FullName}[/]");

        if (settings.Verbose)
        {
            AnsiConsole.MarkupLine($"[yellow]Max read lines: {settings.MaxReadLines}[/]");
        }

        // write new string('-', Console.WindowWidth)
        var separator = new string('-', Console.WindowWidth);
        AnsiConsole.MarkupLine($"[green]{separator}[/]");

        CommonService.ReadFile(fileInfo, settings.MaxReadLines);

        return 0;
    }
}
