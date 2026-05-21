namespace EncryptionTool
{
    // Observer Pattern: Olayları dinleyecek nesneler için arayüz
    public interface IObserver
    {
        void Update(string eventName, string message);
    }
}
