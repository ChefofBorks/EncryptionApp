
using EncryptionApp.AesEncryption;
using EncryptionApp.Common;
using System.CommandLine;


namespace EncryptionApp.Commands
{
    public static class DecryptCommand
    {
        public static Command Create()
        {
            var textArgument   = StaticHelpers.TextArgument("Encrypted text");
            var command        = StaticHelpers.GetCommand("decrypt", "Decrypt text");

            command.Arguments.Add(textArgument);

            command.SetAction(parseResult =>
            {
                try
                {
                    string text      = parseResult.GetValue(textArgument)!;

                    string password  = SecureInput.ReadPassword();

                    string decrypted = Decryption.Decrypt(text, password);

                    Console.WriteLine(decrypted);

                    return 0;
                }
                catch
                {
                    Console.WriteLine("Invalid password or encrypted text.");

                    return 1;
                }
            });

            return command;
        }
    }
}
