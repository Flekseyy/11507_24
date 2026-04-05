namespace CoffeeMachine;

public class DailyReport
{
    public string Date { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalSales { get; set; }
    public List<SalesRecord> Sales { get; set; } = new();
}