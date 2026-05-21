using System;

namespace EncryptionTool
{
    // Decorator Base Sınıfı
    public abstract class EncryptorDecorator : IEncryptor
    {
        protected readonly IEncryptor _wrappee;

        public EncryptorDecorator(IEncryptor wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual string Encrypt(string data)
        {
            return _wrappee.Encrypt(data);
        }

        public virtual string Decrypt(string data)
        {
            return _wrappee.Decrypt(data);
        }
    }
}
