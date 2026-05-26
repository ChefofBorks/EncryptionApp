
using System.Security;


namespace EncryptionApp.Common
{
    public static class SecureInput
    {
        public static string ReadPassword(string prompt = "Enter password: ")
        {
            Console.Write(prompt);

            var password = new SecureString();

            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.RemoveAt(password.Length - 1);
                        Console.Write("\b \b");
                    }

                    continue;
                }

                password.AppendChar(key.KeyChar);
                Console.Write("*");
            }

            password.MakeReadOnly();

            return new System.Net.NetworkCredential(string.Empty, password).Password;
        }
    }
}
