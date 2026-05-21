using System;

namespace EncryptionTool
{
    public class Base64Encryptor : IEncryptor
    {
        public string Encrypt(string data)
        {
            Console.WriteLine("Base64 ile encode ediliyor...");
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
        }

        public string Decrypt(string data)
        {
            Console.WriteLine("Base64 ile decode ediliyor...");
            var bytes = Convert.FromBase64String(data);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
