using McMaster.Extensions.CommandLineUtils;
var app = new CommandLineApplication
{
    Name = "lab4",
    Description = "Lab 4 Chabanenko",
};
app.HelpOption(inherited: true);

app.Command("version", cmdx =>
{
    cmdx.OnExecute(() =>
    {
        Console.WriteLine("version 0.1\nCreated by Chabanenko Max IPZ-41");
        return 1;
    }); 
});
string LAB_PATH = "";
app.Command("set-path", cmd =>
{
    var a = cmd.Option("-p|--path", "path to files", CommandOptionType.SingleValue).IsRequired();
    cmd.OnExecute(() =>
    {
        LAB_PATH = a.Value();
        Console.WriteLine("Path is set to");
        Console.WriteLine(LAB_PATH);
        return 1;
    });
});

app.Command("run", configCmd =>
{
    configCmd.OnExecute(() =>
    {
        Console.WriteLine("Specify a lab to run");
        return 1;
    });

    configCmd.Command("lab1", lab1Cmd =>
    {
        lab1Cmd.Description = "Run lab1";

        var input = lab1Cmd.Option("-i|--input", "input file", CommandOptionType.SingleValue);
        var output = lab1Cmd.Option("-o|--output", "output file", CommandOptionType.SingleValue);

        string inputPath = null;
        string outputPath = null;
        lab1Cmd.OnExecute(() =>
        {
            bool inExists = File.Exists(input.Value());
            bool outExists = File.Exists(output.Value());

            if (input.Value() != null && inExists)
                inputPath = input.Value();

            if (output.Value() != null && outExists)
                outputPath = output.Value();

            if (!inExists || !outExists)
            {
                inputPath = LAB_PATH + "\\input.txt";
                outputPath = LAB_PATH + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (!inExists || !outExists)
            {
                var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                inputPath = homePath + "\\input.txt";
                outputPath = homePath + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (inExists && outExists)
            {
                Console.WriteLine("___________Running lab1___________");
                Console.WriteLine("inputData = " + inputPath);
                Console.WriteLine("outputData = " + outputPath);

                int count = 0;
                lab1.Program1.Output(lab1.Program1.Divide(lab1.Program1.Input(inputPath),ref count), outputPath);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        });
    });
    configCmd.Command("lab2", lab1Cmd =>
    {
        lab1Cmd.Description = "Run lab2";

        var input = lab1Cmd.Option("-i|--input", "input file", CommandOptionType.SingleValue);
        var output = lab1Cmd.Option("-o|--output", "output file", CommandOptionType.SingleValue);

        string inputPath = null;
        string outputPath = null;
        lab1Cmd.OnExecute(() =>
        {
            bool inExists = File.Exists(input.Value());
            bool outExists = File.Exists(output.Value());

            if (input.Value() != null && inExists)
                inputPath = input.Value();

            if (output.Value() != null && outExists)
                outputPath = output.Value();

            if (!inExists || !outExists)
            {
                inputPath = LAB_PATH + "\\input.txt";
                outputPath = LAB_PATH + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (!inExists || !outExists)
            {
                var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                inputPath = homePath + "\\input.txt";
                outputPath = homePath + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (inExists && outExists)
            {
                Console.WriteLine("___________Running lab2___________");
                Console.WriteLine("inputData = " + inputPath);
                Console.WriteLine("outputData = " + outputPath);

                int count = 0;
                lab2.Program2.Main(new string[] { inputPath });
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        });
    });

    configCmd.Command("lab3", lab1Cmd =>
    {
        lab1Cmd.Description = "Run lab3";

        var input = lab1Cmd.Option("-i|--input", "input file", CommandOptionType.SingleValue);
        var output = lab1Cmd.Option("-o|--output", "output file", CommandOptionType.SingleValue);

        string inputPath = null;
        string outputPath = null;
        lab1Cmd.OnExecute(() =>
        {
            bool inExists = File.Exists(input.Value());
            bool outExists = File.Exists(output.Value());

            if (input.Value() != null && inExists)
                inputPath = input.Value();

            if (output.Value() != null && outExists)
                outputPath = output.Value();

            if (!inExists || !outExists)
            {
                inputPath = LAB_PATH + "\\input.txt";
                outputPath = LAB_PATH + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (!inExists || !outExists)
            {
                var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                inputPath = homePath + "\\input.txt";
                outputPath = homePath + "\\output.txt";

                inExists = File.Exists(inputPath);
                outExists = File.Exists(outputPath);
            }
            if (inExists && outExists)
            {
                Console.WriteLine("___________Running lab3___________");
                Console.WriteLine("inputData = " + inputPath);
                Console.WriteLine("outputData = " + outputPath);

                int count = 0;
                lab3.Program3.Main(new string[] { inputPath });
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        });
    });

});
app.OnExecute(() =>
{
    Console.WriteLine("Specify a command to run");

    return 1;
});

return app.Execute(args);

