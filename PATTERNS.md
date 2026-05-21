# Tasarım Örüntüleri Seçimi (Pattern Seçimleri)

## Faz 1: Factory Method Örüntüsü
Bu aşamada nesne yaratım sorumluluğunu ayırmak için **Factory Method** (veya Simple Factory) kalıbını tercih ettik.

### Neden Factory Method?
Başlangıçtaki `EncryptionProvider` sınıfı "hangi nesnenin ne şekilde üretileceğini" kendi içerisinde barındırıyor (Tight Coupling) ve if-else yığınlarına yol açıyordu. Sorumlulukların ayrılması ilkesine (SRP) uyarak şifreleme sınıfının asıl görevine odaklanmasını sağlamak istedik.

Factory Method kullanmak:
1. **İzolasyon**: Üretim mantığını `EncryptorFactory` adlı tek bir sınıfa izole etti. `EncryptionProvider` sınıfının algoritma oluşturma detaylarını bilmesine gerek kalmadı.
2. **Esneklik**: Yeni bir algoritma (ör. `DesEncryptor`) eklendiğinde sadece factory içerisine bir satır eklenecek, diğer kısımlar etkilenmeyecek.

(İlerleyen aşamalarda Factory'deki switch/if bloklarından tamamen kurtulmak için daha gelişmiş IoC/DI veya yansıma -reflection- teknikleri de eklenebilir, fakat temel amaç olan oluşturma mantığının ayrıştırılması başarıyla sağlandı.)
