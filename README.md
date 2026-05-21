# Yazılım Tasarım Örüntüleri Ödevi - Şifreleme Aracı

## Neden "E" (Şifreleme Aracı) Seçildi?
Bu projede şifreleme aracını seçmemin temel nedeni, siber güvenliğe olan kişisel ilgimdir. Güvenlik yazılımlarında algoritmaların değişebilirliği (örneğin eski bir algoritmanın yerine hızlıca yenisinin entegre edilebilmesi) kritik bir öneme sahiptir. Nesne tabanlı tasarım örüntüleri, bu tarz esneklikleri sağlamak için en uygun zeminleri sunar.

Projede, başlangıçta kötü tasarlanmış (God Class) bir şifreleme sınıfının adım adım **Creational**, **Structural** ve **Behavioral** örüntüler kullanılarak nasıl SOLID prensiplerine uygun, esnek ve genişletilebilir bir mimariye dönüştürüldüğünü görebilirsiniz.

---

## Uygulanan Tasarım Örüntüleri (Design Patterns)

Projemizin refactoring sürecinde aşağıdaki tasarım örüntüleri kullanılmıştır:

1. **Factory Method (Creational):** Nesne üretim sorumluluğunu merkezi bir fabrika sınıfına (`EncryptorFactory`) alarak istemci kod ile şifreleme algoritmaları (`AesEncryptor`, `RsaEncryptor`) arasındaki bağımlılığı (tight coupling) kopardık.
2. **Decorator (Structural):** Mevcut şifreleyici nesnelere dokunmadan çalışma anında dinamik olarak ek davranışlar (örneğin `LoggingDecorator` ile loglama) kazandırdık.
3. **Facade (Structural):** Factory ve Decorator bileşenlerinin istemci tarafından kullanım zorluğunu gizlemek için tek bir `EncryptionFacade` servisi sağladık.
4. **Strategy (Behavioral):** Şifreleme algoritmasını `EncryptionContext` üzerinden çalışma anında değiştirilebilir (`SetStrategy`) hale getirip if-else bloklarından tamamen kurtulduk.
5. **Observer (Behavioral):** Şifreleme işlemleri sırasında veya hata anında sistemi izleyen bağımsız birimleri (`AdminObserver`, `LoggerObserver`) otomatik olarak uyaracak olay tabanlı bir sistem kurduk.

---

## Final Mimari UML Diyagramı

```mermaid
classDiagram
    class IEncryptor {
        +Encrypt(string data) string
        +Decrypt(string data) string
    }
    <<interface>> IEncryptor

    class EncryptorFactory {
        +CreateEncryptor(string algorithmType) IEncryptor
    }

    class EncryptorDecorator {
        #IEncryptor _wrappee
        +Encrypt(string data) string
        +Decrypt(string data) string
    }
    <<abstract>> EncryptorDecorator

    class LoggingDecorator {
        +Encrypt(string data) string
        +Decrypt(string data) string
    }

    class EncryptionContext {
        -IEncryptor _strategy
        -List~IObserver~ _observers
        +SetStrategy(IEncryptor strategy)
        +AttachObserver(IObserver observer)
        +ExecuteEncryption(string data) string
    }

    class IObserver {
        +Update(string eventName, string message)
    }
    <<interface>> IObserver

    class EncryptionFacade {
        -EncryptorFactory _factory
        +EncryptWithLogging(string algorithmType, string data) string
    }

    IEncryptor <|.. AesEncryptor
    IEncryptor <|.. RsaEncryptor
    IEncryptor <|.. Base64Encryptor
    
    IEncryptor <|.. EncryptorDecorator
    EncryptorDecorator <|-- LoggingDecorator
    EncryptorDecorator o-- IEncryptor : wraps

    EncryptionContext o-- IEncryptor : uses strategy
    EncryptionContext o-- IObserver : notifies
    
    IObserver <|.. LoggerObserver
    IObserver <|.. AdminObserver

    EncryptionFacade --> EncryptorFactory : calls
    EncryptionFacade ..> LoggingDecorator : uses
```
