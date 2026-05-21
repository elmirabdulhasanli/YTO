# Faz 2: AI Log - Facade mi, Adapter mi?

**Kullanıcı:**
"İstemcinin (Client) `EncryptorFactory`, `LoggingDecorator` ve ilgili şifreleme nesnelerini sırayla manuel oluşturup birleştirmesi kod kirliliği yaratıyor. Bunu toparlamak için Adapter mi kullanmalıyım yoksa Facade mi?"

**AI Yanıtı:**
Bu senaryo için kesinlikle **Facade** kullanmalısın! 

İki örüntünün farkı şudur:
- **Adapter**: Amacı, birbiriyle uyumsuz iki arayüzü (interface) konuşturmaktır. Örneğin, elinde üçüncü parti bir `X_EncryptionLib` kütüphanesi olsaydı ve bu kütüphane senin `IEncryptor` arayüzüne uymasaydı (metot adları vb. farklı olsaydı), araya bir Adapter yazarak onları uyumlu hale getirirdin.
- **Facade**: Amacı, karmaşık bir alt sistemin (bizim senaryoda Factory nesnesi, Decorator nesnesi ve bunların sarmalanması işlemleri) önüne basit, tek bir kullanım noktası (arayüz/sınıf) koymaktır. 

Bizim problemimiz uyumsuzluk değil, **karmaşıklık**. İstemcinin çok sayıda nesne üretip sarmalama yapmasını (Decorator wrap işlemi) engellemek için `EncryptionFacade` (veya Service) yazdık. İstemci sadece "Bana AES loglu şifreleme yap" der, gerisini Facade halleder.
