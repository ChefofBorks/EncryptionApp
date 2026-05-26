
using System.CommandLine;
using EncryptionApp.Commands;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("EncryptionApp AES CLI Utility");

        rootCommand.Subcommands.Add(EncryptCommand.Create());
        rootCommand.Subcommands.Add(DecryptCommand.Create());

        return await rootCommand.Parse(args).InvokeAsync();
    }
}