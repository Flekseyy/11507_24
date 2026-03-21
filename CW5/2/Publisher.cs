namespace CW5;

public class Publisher
{
    public delegate void Event(string info);
    public event Event OnDataReceived;
        
    public void GenerateData(string info)
    {
        Console.WriteLine($"Отправка {info}");
        OnDataReceived?.Invoke(info);
    }
    
}

