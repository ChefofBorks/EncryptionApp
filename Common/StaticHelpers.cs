

using System.CommandLine;


namespace EncryptionApp.Common
{
    public static class StaticHelpers
    {
        public static Argument<string> TextArgument(string description) =>
            new("text") 
        { 
            Description = description 
        };

        public static Command GetCommand(string name, string description) => 
            new Command(name, description);
    }
}
