using System;
using System.Collections.Generic;

namespace EncryptionTool
{
    // Strategy ve Observer kalıplarını barındıran Context sınıfı
    public class EncryptionContext
    {
        // STRATEGY: Şifreleme algoritmasını tutan referans
        private IEncryptor _strategy;
        
        // OBSERVER: Dinleyici listesi
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void SetStrategy(IEncryptor strategy)
        {
            _strategy = strategy;
            NotifyObservers("STRATEGY_CHANGED", $"Yeni şifreleme stratejisi atandı: {_strategy.GetType().Name}");
        }

        public void AttachObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers(string eventName, string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(eventName, message);
            }
        }

        public string ExecuteEncryption(string data)
        {
            if (_strategy == null)
            {
                var errorMsg = "Şifreleme stratejisi seçilmedi!";
                NotifyObservers("ERROR", errorMsg);
                throw new InvalidOperationException(errorMsg);
            }

            try
            {
                NotifyObservers("ENCRYPT_START", "Şifreleme başlıyor.");
                var result = _strategy.Encrypt(data);
                NotifyObservers("ENCRYPT_SUCCESS", "Şifreleme başarıyla tamamlandı.");
                return result;
            }
            catch (Exception ex)
            {
                NotifyObservers("ERROR", $"Şifreleme sırasında hata oluştu: {ex.Message}");
                throw;
            }
        }
    }
}
