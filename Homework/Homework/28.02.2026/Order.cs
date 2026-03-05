namespace Homework;
using System.Numerics;


public interface IIdStep<T> where T : INumber<T>
{
   IPriceStep<T> SetId(int id);
}
public interface  IPriceStep<T> where T : INumber<T>
{
    IFinalStep<T> SetBasePrice(T basePrice);
}

public interface IFinalStep<T> where T : INumber<T>
{
    Order<T> Build();
}
public class Order<T> where T : INumber<T>
{
    public int Id { get; internal set; }
    public T BasePrice { get; internal set; }
    public T FinalPrice { get; internal set; }
    
}