# Faz 3: AI Log - Pair Programming Özeti

**Tarih:** 21 Mayıs 2026
**Süre:** ~30 Dakika
**Konu:** Behavioral (Davranışsal) Örüntülerin (Strategy ve Observer) Entegrasyonu

## Gündem ve Yapılanlar
Bu pair programming oturumunda şifreleme aracımızın en kritik eksikliklerinden olan "çalışma anında esneklik" ve "olay bazlı bildirim" özelliklerini çözmeye odaklandık.

1. **Strategy Pattern Kararı:**
   - *Sorun:* Şifreleme algoritması, Factory kullanmamıza rağmen hala kod içinde bazı statik karar noktalarına bağlı olabilirdi. Algoritmayı çalışma anında (runtime) kullanıcı seçimine göre değiştirmek istiyorduk.
   - *Çözüm:* `EncryptionContext` sınıfını oluşturduk. `SetStrategy(IEncryptor strategy)` metodu ile algoritma nesnesini dinamik olarak değiştirebilir hale geldik. Artık "Açık-Kapalı Prensibi" (OCP) tamamen sağlanmış oldu; yeni bir algoritma gelirse tek yapmamız gereken onu Factory'den üretip Context'e set etmek.

2. **Observer Pattern Kararı:**
   - *Sorun:* Şifreleme tamamlandığında veya bir hata olduğunda (örneğin strateji seçilmediğinde) sistemin farklı bileşenlerinin (Loglama, Admin paneli vb.) haberdar olması gerekiyordu. Bunları Context içine sıkıştırmak yine "Tight Coupling" yaratacaktı.
   - *Çözüm:* `IObserver` arayüzünü ve onu uygulayan `LoggerObserver`, `AdminObserver` sınıflarını tasarladık. `EncryptionContext` sınıfı bir olay (event) gerçekleştiğinde listesindeki tüm gözlemcilere (observers) haber veriyor (NotifyObservers).

3. **CI/CD Kurulumu:**
   - Pair programming'in son aşamasında GitHub Actions için `.github/workflows/ci.yml` dosyasını oluşturarak sistemin sürdürülebilir bir şekilde her push sonrası otomatik derlenmesini (build) sağladık.

## Sonuç
Projemiz "God Class" adlı anti-pattern'den başlayıp; nesne üretiminin ayrıştırıldığı (Creational), karmaşıklığın gizlendiği (Structural) ve davranışların çalışma anında esnekçe yönetilebildiği (Behavioral) tam teşekküllü, SOLID prensiplerine uygun bir sisteme evrilmiştir.
