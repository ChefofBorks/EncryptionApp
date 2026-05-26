
using System.Security.Cryptography;
using System.Text;


namespace EncryptionApp.AesEncryption
{
    public static class Encryption
    {
        public static string Encrypt(string plainText, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            using var keyDerivation = new Rfc2898DeriveBytes(password,
                                                             salt,
                                                             100_000,
                                                             HashAlgorithmName.SHA256
            );

            byte[] key = keyDerivation.GetBytes(32);

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.GenerateIV();

            using MemoryStream ms = new();

            ms.Write(salt, 0, salt.Length);
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (CryptoStream cs = new(ms,
                                         aes.CreateEncryptor(),
                                         CryptoStreamMode.Write)
            )
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                cs.Write(plainBytes, 0, plainBytes.Length);
            }

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
