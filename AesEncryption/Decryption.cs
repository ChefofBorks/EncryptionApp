
using System.Security.Cryptography;


namespace EncryptionApp.AesEncryption
{
    public static class Decryption
    {
        public static string Decrypt(string encryptedText, string password)
        {
            byte[] fullCipher = Convert.FromBase64String(encryptedText);

            byte[] salt = fullCipher[..16];
            byte[] iv = fullCipher[16..32];
            byte[] cipherText = fullCipher[32..];

            using var keyDerivation = new Rfc2898DeriveBytes(password,
                                                             salt,
                                                             100_000,
                                                             HashAlgorithmName.SHA256
            );

            byte[] key = keyDerivation.GetBytes(32);

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using MemoryStream ms = new(cipherText);

            using CryptoStream cs = new(ms,
                                        aes.CreateDecryptor(),
                                        CryptoStreamMode.Read
            );

            using StreamReader reader = new(cs);

            return reader.ReadToEnd();
        }
    }
}
