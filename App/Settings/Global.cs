using System.ComponentModel;
using Spectre.Console.Cli;

namespace App.Settings;

internal class GlobalSettings : CommandSettings
{
    [CommandOption("-v|--verbose")]
    [Description("Enable verbose output")]
    [DefaultValue(false)]
    public bool Verbose { get; init; }
}
