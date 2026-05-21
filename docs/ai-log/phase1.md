# Faz 1: AI Log - Factory Method Tartışması

**Kullanıcı:**
"God Class probleminden kurtulmak için ilk adımda nesne üretimini nasıl ayırabiliriz? Hangi Creational pattern en uygundur?"

**AI Yanıtı:**
Nesne üretimini istemci (client) koddan ayırmak için **Factory Method** (veya Abstract Factory, Simple Factory vb.) kalıplarından birini kullanabiliriz. Bizim senaryomuzda aynı arayüzü (`IEncryptor`) uygulayan farklı algoritma sınıflarımız (`AesEncryptor`, `RsaEncryptor`) var. Bunları oluşturmak için basit bir **Factory Method (ya da Simple Factory)** yapısı yeterlidir.

Oluşturduğumuz `EncryptorFactory` sınıfı `CreateEncryptor(string algorithmType)` metodunu içerir. `EncryptionProvider` veya istemci kod artık sadece "Bana AES ver" diyecektir. O nesnenin nasıl oluşturulduğu, constructor'ının nasıl ayarlandığı yalnızca Factory'nin sorumluluğundadır. 

Böylelikle *Single Responsibility Principle (Tek Sorumluluk Prensibi)*'nin ilk büyük kazanımını elde etmiş oluyoruz: **İş mantığı (şifreleme/çözme) ile nesne oluşturma mantığı birbirinden ayrıldı.**
