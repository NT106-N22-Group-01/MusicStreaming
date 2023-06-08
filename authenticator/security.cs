using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace authenticator
{
    public class security
    {

        private static readonly byte[] salt = Encoding.ASCII.GetBytes("Your Salt Value");

        private static byte[] GetSalt()
        {
            using (var sr = new StreamReader("C:\\Users\\Yumie\\Documents\\NetDev\\finale\\db\\salt.txt"))
            {
                return Encoding.ASCII.GetBytes(sr.ReadLine());
            }
        }

        private static string GetPass()
        {
            using (var sr = new StreamReader("C:\\Users\\Yumie\\Documents\\NetDev\\finale\\db\\pass.txt"))
            {
                byte[] bytes = Convert.FromBase64String(sr.ReadLine());
                return Encoding.ASCII.GetString(bytes);
            }
        }

        public static string Encrypt(string input)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.ASCII.GetBytes(input);

            using (var aesAlgo = new AesCryptoServiceProvider())
            {
                var key = new Rfc2898DeriveBytes(GetPass(), GetSalt());
                aesAlgo.Key = key.GetBytes(aesAlgo.KeySize / 8);
                aesAlgo.IV = key.GetBytes(aesAlgo.BlockSize / 8);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, aesAlgo.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedInput)
        {
            byte[] decryptedBytes;
            byte[] encryptedBytes = Convert.FromBase64String(encryptedInput);

            using (var aesAlgo = new AesCryptoServiceProvider())
            {
                var key = new Rfc2898DeriveBytes(GetPass(), GetSalt());
                aesAlgo.Key = key.GetBytes(aesAlgo.KeySize / 8);
                aesAlgo.IV = key.GetBytes(aesAlgo.BlockSize / 8);

                using (var msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, aesAlgo.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var msPlain = new MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlain);
                            decryptedBytes = msPlain.ToArray();
                        }
                    }
                }
            }
            return Encoding.ASCII.GetString(decryptedBytes);
        }
    }
}
