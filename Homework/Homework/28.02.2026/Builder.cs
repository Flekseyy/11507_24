namespace Homework;
using System.Numerics;


public class OrderBuilder<T> : IIdStep<T>, IPriceStep<T>,IFinalStep<T> where T: INumber<T>
{
    private readonly Order<T> _order =  new Order<T>();
    
    public IPriceStep<T> SetId(int id)
    {
        if (id < 0) throw new ArgumentException("ID не может быть отрицательным");
        _order.Id = id;
        return this;
    }

    public IFinalStep<T> SetBasePrice(T price)
    {
        if(price < T.Zero)throw new ArgumentException("Price не может быть отрицательным");
            _order.BasePrice = price;
            return this;
    }

    public Order<T> Build() 
    {
        Console.WriteLine("Заказ готов");
        return _order;
    }
}

