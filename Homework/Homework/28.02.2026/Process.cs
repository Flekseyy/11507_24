namespace Homework;
using System.Numerics;
public class OrderProcess
{
    public static void Process<T>(Order<T> order, OrderHandler<T> handler) 
        where T : INumber<T>
    {
        Console.WriteLine($"ID: {order.Id}");
        Console.WriteLine($"Price: {order.BasePrice}");
        handler.Handle(order);
        Console.WriteLine($"Заказ {order.Id} выполнен");
    }
}