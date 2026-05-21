using System;

namespace EncryptionTool
{
    // GOD CLASS: Bütün şifreleme algoritmalarını tek bir sınıf içerisinde tutan "kötü tasarım" örneği.
    public class EncryptionProvider
    {
        private readonly string _algorithm;

        public EncryptionProvider(string algorithm)
        {
            _algorithm = algorithm;
        }

        public string Encrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            if (_algorithm == "AES")
            {
                // Simüle edilmiş AES şifreleme işlemi
                Console.WriteLine("AES algoritması ile şifreleniyor...");
                return $"[AES_ENCRYPTED]_{data}";
            }
            else if (_algorithm == "RSA")
            {
                // Simüle edilmiş RSA şifreleme işlemi
                Console.WriteLine("RSA algoritması ile asimetrik şifreleniyor...");
                return $"[RSA_ENCRYPTED]_{data}";
            }
            else if (_algorithm == "Base64")
            {
                // Simüle edilmiş Base64 Encoding
                Console.WriteLine("Base64 ile encode ediliyor...");
                return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
            }
            else
            {
                throw new NotSupportedException($"Algoritma desteklenmiyor: {_algorithm}");
            }
        }

        public string Decrypt(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            if (_algorithm == "AES")
            {
                Console.WriteLine("AES algoritması ile çözülüyor...");
                return data.Replace("[AES_ENCRYPTED]_", "");
            }
            else if (_algorithm == "RSA")
            {
                Console.WriteLine("RSA algoritması ile çözülüyor...");
                return data.Replace("[RSA_ENCRYPTED]_", "");
            }
            else if (_algorithm == "Base64")
            {
                Console.WriteLine("Base64 ile decode ediliyor...");
                var bytes = Convert.FromBase64String(data);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
            else
            {
                throw new NotSupportedException($"Algoritma desteklenmiyor: {_algorithm}");
            }
        }
    }
}
