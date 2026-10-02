using System.CommandLine;

namespace App.Option;

static partial class CommonOption
{
    public const string HelpFlag = "--help";

    public static Option<bool> NewHelpOption()
    {
        Option<bool> option = new(HelpFlag)
        {
            Description = "Show help information"
        };

        return option;
    }
}
