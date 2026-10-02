using App.Command;
using Spectre.Console.Cli;

namespace App;

partial class Program
{
    static int Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config.SetApplicationName("sam-reader");
            //
            config.AddCommand<GreetCommand>("greet")
                .WithDescription("Greet a person")
                .WithExample("greet", "Sam");

            config.AddBranch("read", read =>
            {
                read.SetDescription("Operations related to reading files");
                read.AddCommand<ReadFileCommand>("file")
                    .WithAlias("f")
                    .WithDescription("Read a file")
                    .WithExample("read", "file", "path/to/file.txt", "--max-read-lines", "3");
            });

            #if DEBUG
                config.PropagateExceptions();
                config.ValidateExamples();
            #endif
        });


        return app.Run(args);
    }
}
