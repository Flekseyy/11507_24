namespace Homework;

using System.Numerics;

public abstract class OrderHandler<T> where T : INumber<T>
{
    protected OrderHandler<T> _nextorder;

    public OrderHandler<T> SetNext(OrderHandler<T> order)
    {
        _nextorder = order;
        return order;
    }

    public abstract void Handle(Order<T> order);
}

public class DiscountHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _discount;
    
    public DiscountHandler(T discount)
    {
        if (discount < T.Zero) throw new ArgumentOutOfRangeException(nameof(discount));
        _discount = discount;
    }
    public override void Handle(Order<T> order)
    {   
        order.BasePrice = order.BasePrice - _discount;
        _nextorder?.Handle(order);
    }
    
}

public class TaxHandler<T> : OrderHandler<T> where T : INumber<T>
{
    private readonly T _tax;
    public TaxHandler(T tax)
    {
        if (tax < T.Zero) throw new ArgumentOutOfRangeException(nameof(tax));
        _tax =tax;
    }
    public override void Handle(Order<T> order)
    {
        order.BasePrice = order.BasePrice * T.CreateChecked(_tax);
        _nextorder?.Handle(order);
    }
}

public class ValidationHandler<T> : OrderHandler<T> where T : INumber<T>
{
    public override void Handle(Order<T> order)
    {
        if (order.BasePrice < T.Zero)  
            throw new InvalidOperationException(
            $"Цена не может быть отрицательной! Текущая цена: {order.BasePrice}");
        order.FinalPrice = order.BasePrice;

    }
}



