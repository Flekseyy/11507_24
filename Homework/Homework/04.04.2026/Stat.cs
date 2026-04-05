namespace CoffeeMachine;

public class Statistics
{
    private readonly Dictionary<string, int> _coffeeSales = new();
    private readonly Dictionary<string, int> _syrupSales = new();
    private int _totalToppings = 0;

    public void RecordCoffee(string name)
    {
        if (!_coffeeSales.ContainsKey(name)) _coffeeSales[name] = 0;
        _coffeeSales[name]++;
    }

    public void RecordSyrup(string name)
    {
        if (!_syrupSales.ContainsKey(name)) _syrupSales[name] = 0;
        _syrupSales[name]++;
        _totalToppings++;
    }

    public void ShowReport()
    {
        Console.Clear();
        Console.WriteLine("=== СТАТИСТИКА ===\n");
            
        Console.WriteLine("Кофе:");
        foreach (var s in _coffeeSales)
            Console.WriteLine($"  {s.Key}: {s.Value}");
            
        Console.WriteLine($"\nДоппингов всего: {_totalToppings}");
        foreach (var s in _syrupSales)
            Console.WriteLine($"  {s.Key}: {s.Value}");
            
        Console.WriteLine("\nEnter...");
        Console.ReadLine();
    }
}