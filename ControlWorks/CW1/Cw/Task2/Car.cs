using System.Globalization;

namespace Task2;

public class Car
{
    public string Model { get; set; }
    public int CurrentSpeed { get; private set; }
    public event EventHandler<int> SpeedExceeded;

    public void Accelerate(int amount)
    {
        CurrentSpeed += amount;
        if (CurrentSpeed >= 110)
        {
            SpeedExceeded?.Invoke(this, CurrentSpeed);
        }
        
    }
}