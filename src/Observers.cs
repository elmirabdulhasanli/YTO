using System;

namespace EncryptionTool
{
    public class AdminObserver : IObserver
    {
        public void Update(string eventName, string message)
        {
            if (eventName == "ERROR")
            {
                Console.WriteLine($"[ADMIN BİLDİRİMİ] Kritik Hata Tespit Edildi: {message}");
            }
        }
    }

    public class LoggerObserver : IObserver
    {
        public void Update(string eventName, string message)
        {
            Console.WriteLine($"[SİSTEM LOGU] Olay: {eventName} | Detay: {message}");
        }
    }
}
