using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
using App.Settings;

namespace App.Command;

internal class GreetCommand : Command<GreetCommand.Settings>
{
    public class Settings : GlobalSettings
    {
        [CommandArgument(0, "[name]")]
        [Description("The name to greet")]
        public string Name { get; init; } = string.Empty;

        [CommandOption("-c|--count")]
        [Description("The number of times to greet")]
        public int Count { get; init; } = 1;
    }

    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellation)
    {
        var name = string.IsNullOrEmpty(settings.Name) ? "World" : settings.Name;
        for (int i = 0; i < settings.Count; i++)
        {
            AnsiConsole.MarkupLine($"[green]Hello, {name}![/]");
        }
        return 0;
    }
}
