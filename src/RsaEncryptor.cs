using System;

namespace EncryptionTool
{
    public class RsaEncryptor : IEncryptor
    {
        public string Encrypt(string data)
        {
            Console.WriteLine("RSA algoritması ile asimetrik şifreleniyor...");
            return $"[RSA_ENCRYPTED]_{data}";
        }

        public string Decrypt(string data)
        {
            Console.WriteLine("RSA algoritması ile çözülüyor...");
            return data.Replace("[RSA_ENCRYPTED]_", "");
        }
    }
}
