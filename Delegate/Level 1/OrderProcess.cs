using System.Globalization;

namespace Delegate.Level_1;
public delegate void LogHandler(string message);
public class OrderProcess
{
    public LogHandler? Log;
    public void Process()
    {   
        Log?.Invoke("Заказ принят");
        Log?.Invoke("Платеж прошел");
        Log?.Invoke("Заказ отправлен");
    }
}
