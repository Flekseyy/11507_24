using System.Globalization;

namespace Task2;
public class Program
{
    public static void DisplayMessage(string info) => Console.WriteLine(info);
    
    public static void Main()
    {
        
        Car car = new Car();
        car.Model = "BMW";
        car.Accelerate(90);
        car.SpeedExceeded += (sender, speed) => DisplayMessage($"Сбавьте скорость! Текущая: {speed} км/ч");
        car.Accelerate(20); 
        car.Accelerate(20);
    }
  


}