using System;

namespace EncryptionTool
{
    public class EncryptorFactory
    {
        public virtual IEncryptor CreateEncryptor(string algorithmType)
        {
            if (string.Equals(algorithmType, "AES", StringComparison.OrdinalIgnoreCase))
            {
                return new AesEncryptor();
            }
            else if (string.Equals(algorithmType, "RSA", StringComparison.OrdinalIgnoreCase))
            {
                return new RsaEncryptor();
            }
            else if (string.Equals(algorithmType, "BASE64", StringComparison.OrdinalIgnoreCase))
            {
                return new Base64Encryptor();
            }
            else
            {
                throw new NotSupportedException($"Desteklenmeyen algoritma: {algorithmType}");
            }
        }
    }
}
