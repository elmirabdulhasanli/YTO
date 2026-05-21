# Temel Sınıfın Problemleri (God Class Analizi)

Şu anda yazılmış olan `EncryptionProvider` sınıfı, nesne yönelimli programlamada (OOP) kaçınılması gereken bazı temel hatalara sahiptir. Aşağıda bu yapının sebep olduğu 5 kritik problem listelenmiştir:

## 1. Açık-Kapalı Prensibi (Open-Closed Principle - OCP) İhlali
Sınıfın mevcut yapısında yeni bir algoritma (örneğin DES, Blowfish vb.) eklemek istediğimizde var olan `Encrypt` ve `Decrypt` metodlarına yeni `if-else` blokları eklemek zorundayız. Oysa iyi bir tasarımda sınıflar **genişletilmeye açık (open for extension)**, **değiştirilmeye kapalı (closed for modification)** olmalıdır.

## 2. Tek Sorumluluk Prensibi (Single Responsibility Principle - SRP) İhlali
Sınıf aynı anda AES şifreleme, RSA asimetrik şifreleme ve Base64 kodlama mantığını barındırıyor. Bu durum, sınıfın birden fazla değişim nedeni (reason to change) olmasına yol açıyor.

## 3. Sıkı Bağımlılık (Tight Coupling) ve "God Class" Antipattern'i
Bütün iş mantığı tek bir sınıfa sıkıştırılmıştır. Herhangi bir algoritmanın altyapısı değiştiğinde (örneğin RSA için key-size parametresi eklendiğinde) sınıfın kurucusu (constructor) ve if-else yapısı bozulma riski taşır. Bağımlılıklar soyut (abstract) değil, somut (concrete) kodlara (if-else içi logic) verilmiştir.

## 4. Esneklik Eksikliği (Lack of Runtime Flexibility)
Algoritma seçimi constructor aşamasında string ile sabitleniyor. Runtime sırasında (çalışma anında) dinamik olarak aynı `EncryptionProvider` nesnesinin algoritmasını değiştirmek (Örneğin verinin bir kısmını AES ile şifreleyip ardından hemen RSA'ya geçmek) mümkün değildir. 

## 5. Test Edilebilirlik Zorluğu (Hard to Test)
`if-else` blokları uzadıkça, bu sınıfın birim testlerini (unit test) yazmak çok daha karmaşık hale gelir. Çünkü test senaryolarını birbirinden bağımsız şekilde izole etmek (mock'lamak) yerine bütün yapıyı tek bir sınıf üzerinden sınamamız gerekir.

---

### Yapay Zeka (AI) Kod İncelemesi ve Kıyaslama

**Kullanıcı Sorusunun Simülasyonu:**
> "Yazdığım `EncryptionProvider.cs` sınıfını tasarım prensipleri açısından nasıl değerlendirirsin?"

**AI Yanıtı:**
> İncelediğim `EncryptionProvider.cs` kodu tam anlamıyla bir "God Class" (Her Şeyi Yapan Sınıf) örneği sergiliyor. Tasarımınızdaki en belirgin sorun, **Open-Closed Principle (OCP)**'nin çiğnenmesidir. Her yeni algoritma talebinde kodu değiştirmek, gelecekte "Spaghetti Code" problemine yol açacaktır. 
> Ayrıca algoritma seçimi bir string üzerinden (`"AES"`, `"RSA"`) yapılıyor ki bu **Magic String** kullanımıdır; hata yapmaya (typo) çok müsaittir.
>
> **Kıyaslama ve Çözüm Önerim:**
> Sizin yukarıda listelediğiniz 5 madde tasarımın yapısal sıkıntılarına doğru bir şekilde parmak basıyor. Çözüm olarak;
> - Nesne üretimindeki karmaşayı çözmek için **Factory Method** (Faz 1).
> - Karmaşık altyapıyı gizlemek ve genişletmek için **Facade** ve **Decorator** (Faz 2).
> - `if-else` bloklarından kurtulup çalışma zamanı esnekliği kazanmak için de **Strategy** pattern (Faz 3) uygulamanızı tavsiye ederim.
