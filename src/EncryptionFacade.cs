using System;

namespace EncryptionTool
{
    // Facade Sınıfı: Kullanıcının karmaşık alt sistemlerle uğraşmasını engeller.
    public class EncryptionFacade
    {
        private readonly EncryptorFactory _factory;

        public EncryptionFacade()
        {
            _factory = new EncryptorFactory();
        }

        public string EncryptWithLogging(string algorithmType, string data)
        {
            // SELF-REVIEW 2: Facade sayesinde istemci, Factory ve Decorator nesnelerini 
            // manuel olarak birleştirmek (new'lemek) zorunda kalmıyor. Tek metodla karmaşıklık gizleniyor.
            IEncryptor encryptor = _factory.CreateEncryptor(algorithmType);
            IEncryptor loggedEncryptor = new LoggingDecorator(encryptor);
            
            return loggedEncryptor.Encrypt(data);
        }

        public string DecryptWithLogging(string algorithmType, string data)
        {
            IEncryptor encryptor = _factory.CreateEncryptor(algorithmType);
            IEncryptor loggedEncryptor = new LoggingDecorator(encryptor);
            
            return loggedEncryptor.Decrypt(data);
        }
    }
}
