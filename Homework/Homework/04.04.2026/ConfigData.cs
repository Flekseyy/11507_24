namespace CoffeeMachine;

public class ConfigData
{
    public Dictionary<string, int> CoffeePrices { get; set; } = new();
    public Dictionary<string, int> SyrupPrices { get; set; } = new();
    public int Water { get; set; } = 1000;
    public int Milk { get; set; } = 500;
    public int Beans { get; set; } = 300;
}
