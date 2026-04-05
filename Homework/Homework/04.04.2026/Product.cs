namespace CoffeeMachine;


public abstract class Product
{
    public string Name { get; }
    public int Price { get; }
    public int Count { get; private set; }

    protected Product(string name, int count, int price)
    {
        Name = name;
        Count = count;
        Price = price;
    }

    public bool IsAvailable => Count > 0;

    public bool DecreaseCount()
    {
        if (Count > 0)
        {
            Count--;
            return true;
        }
        return false;
    }
    public override string ToString() => 
        $"{Name,-12} | {Price,3} руб | {(IsAvailable ? $"{Count} шт." : "НЕТ")}";
}
