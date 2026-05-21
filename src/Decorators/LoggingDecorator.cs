using System;

namespace EncryptionTool
{
    // Concrete Decorator: Şifreleme işlemlerini loglayan yapı
    public class LoggingDecorator : EncryptorDecorator
    {
        public LoggingDecorator(IEncryptor wrappee) : base(wrappee)
        {
        }

        public override string Encrypt(string data)
        {
            Console.WriteLine($"[LOG]: '{data}' verisi şifrelenmeye başlanıyor...");
            
            // SELF-REVIEW 1: Mevcut şifreleme sınıfına dokunmadan, dışarıdan loglama davranışı ekledik (OCP'ye uygun).
            var result = base.Encrypt(data);
            
            Console.WriteLine($"[LOG]: Şifreleme tamamlandı. Sonuç: {result}");
            return result;
        }

        public override string Decrypt(string data)
        {
            Console.WriteLine($"[LOG]: Şifre çözme işlemi başlıyor...");
            var result = base.Decrypt(data);
            Console.WriteLine($"[LOG]: Şifre çözüldü.");
            return result;
        }
    }
}
