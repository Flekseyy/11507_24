using System.ComponentModel;

namespace IIP2;

public class WarehouseStep : PipelineStep<int, Product>
{
    public Dictionary <int, Product> products = new Dictionary<int, Product>
    {
        { 1, new Product("Iphone7",100) },
        { 2, new Product("Iphone9",101)},
        { 3,  new Product("IphoneX",102) },
    };
    public override Product Process(int input)
    {
         if(products.ContainsKey(input)) return products[input]; 
         throw new NotImplementedException();
    }
}
public class PaymentStep : PipelineStep<Product, Recept>
{
    private readonly decimal _userBalance = 1000m;
    public override Recept Process(Product input)
    {
        if (_userBalance < input.Price)
        {
            throw new Exception("Not enough money");
        }

        return new Recept
        {
            ProductName = input.Name,
            FinalPrice = input.Price,
            Date = DateTime.Now
        };
    }
}

public class LoggerStep : PipelineStep<Recept, string>
{
    public override string Process(Recept input)
    {
        return $"Заказ на {input.ProductName} от {input.Date} успешно оплачен ";
    }
}
