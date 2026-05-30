using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _11507_24.Homework._14._03._2026.Secure;


public class Sensor
{
    public event Action<string, DateTime> OnAlert;
    
    public void Trigger(string message)
    {
        Console.WriteLine($"СРАБАТЫВАНИЕ СЕНСОРА: {message}");
        OnAlert?.Invoke(message, DateTime.Now);
    }
}


public class Siren
{
    public void OnAlert(string message, DateTime time)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" ВКЛЮЧЕНА СИРЕНА: [{message}] (в {time:HH:mm:ss})");
        Console.ResetColor();
    }
}

public class Logger
{
    public ObservableCollection<string> Logs { get; } = new();  

    public void OnAlert(string message, DateTime time)
    {
        string logEntry = $"[{time:yyyy-MM-dd HH:mm:ss}] {message}";
        Logs.Add(logEntry);
    }
}

public class LogAnalyzer
{
    public static void AnalyzeLog<T>(IEnumerable<T> logs, Predicate<T> filter)
    {
        Console.WriteLine("Результаты анализа логов");
        int count = 0;
        foreach (var log in logs)
        {
            if (filter(log))
            {
                Console.WriteLine($"+ {log}");
                count++;
            }
        }
        if (count == 0)
            Console.WriteLine("Нет записей, подходящих под фильтр");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        var sensor = new Sensor();
        var siren = new Siren();
        var logger = new Logger();

        sensor.OnAlert += siren.OnAlert;
        sensor.OnAlert += logger.OnAlert;

        logger.Logs.CollectionChanged += (sender, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("💾 Запись добавлена в БД");
                Console.ResetColor();
            }
        };
        
        sensor.Trigger("Обнаружено движение в зоне А");
        sensor.Trigger("Критично: Открыта дверь склада");
        sensor.Trigger("Нормальная температура в помещении");
        sensor.Trigger("Критично: Превышен уровень влажности");

        LogAnalyzer.AnalyzeLog(
            logger.Logs,
            log => log.ToString().Contains("Критично")
        );
        
        foreach (var log in logger.Logs)
        {
            Console.WriteLine(log);
        }
    }
}