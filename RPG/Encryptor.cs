using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace RPG.Backend
{
    public class Encryptor
    {
        private const int KeySize = 256;
        private const int DerivationsIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = RandomBytesGen(32); // Salt is 32 bytes
            var ivStringBytes = RandomBytesGen(16);   // IV should be 16 bytes
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationsIterations))
            {
                var keyBytes = password.GetBytes(KeySize / 8);
                using (var aesAlg = Aes.Create()) // Use AES instead of Rijndael
                {
                    aesAlg.KeySize = KeySize;
                    // BlockSize is always 128 bits for AES, so we don't need to set it manually
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aesAlg.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(32).ToArray(); // Salt is 32 bytes
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(32).Take(16).ToArray(); // IV is 16 bytes
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip(48).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationsIterations))
            {
                var keyBytes = password.GetBytes(KeySize / 8);
                using (var aesAlg = Aes.Create()) // Use AES instead of Rijndael
                {
                    aesAlg.KeySize = KeySize;
                    // BlockSize is always 128 bits for AES, so we don't need to set it manually
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aesAlg.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            using (var streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        private static byte[] RandomBytesGen(int size)
        {
            var randomBytes = new byte[size];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
