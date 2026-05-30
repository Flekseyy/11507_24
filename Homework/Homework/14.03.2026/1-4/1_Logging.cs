namespace _11507_24.Homework._14._03._2026._1_4
{
    public delegate void LogHandler(string message);
    public class OrderProcessor
    {
        private LogHandler _logHandler;

        public OrderProcessor(LogHandler logHandler)
        {
            _logHandler = logHandler;
        }

        public void Process()
        {
            _logHandler?.Invoke("Заказ принят");
            _logHandler?.Invoke("Платеж прошел");
            _logHandler?.Invoke("Заказ отправлен");
        }
    }
    // public class Program
    // {
    //     static void LogRed(string message)
    //     {
    //         ConsoleColor original = Console.ForegroundColor;   
    //         Console.ForegroundColor = ConsoleColor.Red;
    //         Console.WriteLine($"Red - {message}");
    //         Console.ForegroundColor = original;
    //     }
    //     static void LogNormal(string message) => Console.WriteLine($"Normal - {message}");
    //     public static void Main()
    //     {
    //         LogHandler handler = LogRed;
    //         handler += LogNormal;
    //         var processor = new OrderProcessor(handler);
    //         processor.Process();    
    //     }
    // }
}