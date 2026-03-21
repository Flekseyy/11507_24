using System.Diagnostics;

namespace Delegate.Level_1;

public class Run
{
    public static void ToRun()
    {
        var process = new OrderProcess();
        process.Log += LogRed;
        process.Process();
        process.Log -= LogRed;
        process.Log += LogNormal;
        process.Process();
    }
    
    static void LogRed(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[RED] {message}");
        Console.ResetColor();
    }
    
  
    static void LogNormal(string message)
    {
        Console.WriteLine($"[NORMAL] {message}");
    }
}