
using EncryptionApp.AesEncryption;
using EncryptionApp.Common;
using System.CommandLine;


namespace EncryptionApp.Commands
{
    public static class EncryptCommand
    {
        public static Command Create()
        {
            var textArgument   = StaticHelpers.TextArgument("Text to encrypt");
            var command        = StaticHelpers.GetCommand("encrypt", "Encrypt text");

            command.Arguments.Add(textArgument);

            command.SetAction(parseResult =>
            {
                string text      = parseResult.GetValue(textArgument)!;

                string password  = SecureInput.ReadPassword();

                string encrypted = Encryption.Encrypt(text, password);

                Console.WriteLine(encrypted);

                return 0;
            });

            return command;
        }
    }
}
