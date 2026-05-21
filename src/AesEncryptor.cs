using System;

namespace EncryptionTool
{
    public class AesEncryptor : IEncryptor
    {
        public string Encrypt(string data)
        {
            Console.WriteLine("AES algoritması ile şifreleniyor...");
            return $"[AES_ENCRYPTED]_{data}";
        }

        public string Decrypt(string data)
        {
            Console.WriteLine("AES algoritması ile çözülüyor...");
            return data.Replace("[AES_ENCRYPTED]_", "");
        }
    }
}
