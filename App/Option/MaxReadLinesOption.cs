using System.CommandLine;

namespace App.Option;

static partial class CommonOption
{
    public static Option<int> NewMaxReadLinesOption()
    {
        Option<int> maxReadLines = new("--max-read-lines", "-m")
        {
            Description = "The maximum number of lines to read from the file",
        };

        maxReadLines.Validators.Add(result =>
        {
            var value = result.GetValue(maxReadLines);
            if (value < 0)
            {
                result.AddError("ValidationError: --max-read-lines Does not allow negative values");
            }

            if (value == 0)
            {
                result.AddError("ValidationError: --max-read-lines Must be greater than 0");
            }
        });

        return maxReadLines;
    }
}
