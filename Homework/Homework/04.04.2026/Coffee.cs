namespace CoffeeMachine;

public class Coffee : Product
{
    public int Water { get; }
    public int Milk { get; }
    public int Beans { get; }

    public Coffee(string name, int count, int price, int water, int milk, int beans)
        : base(name, count, price)
    {
        Water = water;
        Milk = milk;
        Beans = beans;
    }
}
