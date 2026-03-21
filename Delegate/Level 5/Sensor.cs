using System.Collections.ObjectModel;
using System.Globalization;

namespace Delegate.Level_5;

public class Sensor
{
    public event Action<string,DateTime> OnAlert;
    public void Trigger(string message) => OnAlert?.Invoke(message, DateTime.Now);

    public ObservableCollection<string> Logs { get; } = new ObservableCollection<string>();

    public void Siren(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ВКЛЮЧЕНА СИРЕНА: [{message}]");
        Console.ResetColor();
    }  
    public void Logger(string message, DateTime time)
    {
        string logEntry = $"[{time:HH:mm:ss}] {message}";
        Logs.Add(logEntry);
    }
    
}