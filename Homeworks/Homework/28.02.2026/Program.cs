namespace Homework;

class Program
{
    static void Main(string[] args)
    {
        var order1 = new OrderBuilder<decimal>()
            .SetId(1)
            .SetBasePrice(1000m)
            .Build();
        var handler = new DiscountHandler<decimal>(100m);
        var handlerDis = handler.SetNext(new TaxHandler<decimal>(1.2m));
             handlerDis.SetNext(new ValidationHandler<decimal>());
        handler.Handle(order1);
        OrderProcess.Process(order1, handler);
        
        var order2 = new OrderBuilder<double>()
            .SetId(2)
            .SetBasePrice(500.0)
            .Build();
        var handler2 = new DiscountHandler<double>(50.0);
        var handlerDis2 = handler2.SetNext(new TaxHandler<double>(1.2));
            handlerDis2.SetNext(new ValidationHandler<double>());
        handler2.Handle(order2);
        OrderProcess.Process(order2, handler2);
        
    }
}