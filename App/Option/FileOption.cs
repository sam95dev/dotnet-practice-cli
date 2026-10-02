using System.CommandLine;

namespace App.Option;

static partial class CommonOption
{
    public static Option<FileInfo> NewFileOption(
        string flagName = "--file",
        string shortFlag = "-f",
        string description = "The file to process"
    )
    {
        Option<FileInfo> option = new(flagName, shortFlag)
        {
            Description = description,
            CustomParser = result =>
            {
                var file = new FileInfo(result.Tokens.Single().Value);

                if (!file.Exists)
                {
                    result.AddError("The file does not exist");
                }

                return file;
            }
        };

        return option;
    }
}
