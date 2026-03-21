namespace CW5;

public class Subscriber : IDisposable
{
    private Publisher _publisher;
    private bool _disposed = false;
    public Subscriber(Publisher publisher)
    {
        _publisher = publisher;
        publisher.OnDataReceived += DisplayMessage;
        Console.WriteLine("Подписка");
    }
    public void DisplayMessage(string info) => Console.WriteLine(info);
    
    ~Subscriber()
    {
        Console.WriteLine("Объект Subscriber удален из памяти");
    }

    public void Dispose()
    {
        if (_disposed) return;
        if (!_disposed)
        {
            Console.WriteLine("Отписка");
            if (_publisher != null)
            {
                _publisher.OnDataReceived -= DisplayMessage;
                _publisher = null;
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}