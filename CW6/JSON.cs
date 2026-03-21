using System.Runtime.InteropServices;

namespace CW6;
using System.Text.Json;
public class MyJSON
{
    private List<Item> items;
    private string filePath;
    private JsonSerializerOptions jsonOptions;
    public MyJSON()
    {
        items = new List<Item>();
        var currentDirectory = Directory.GetCurrentDirectory();
        this.filePath = Path.Combine(currentDirectory, "MyItems.json");
        this.jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        LoadFromFile();
 
    }
    public void MyAdd()
    {
        Console.WriteLine("Напишите имя товара");
        string name = Console.ReadLine();
        
        Console.WriteLine("Напишите количество товара");
        int count = int.TryParse(Console.ReadLine(),out int cnt) ? cnt : 0;
        
        Console.WriteLine("Напишите цену товара");
        decimal price = decimal.TryParse(Console.ReadLine(),out decimal pr) ? pr : 0;
        
        items.Add(new Item(name, count, price));
        SaveToFile();
        Console.WriteLine("Добавлен товар");
    }

    public void Delete()
    {
        Print();
        Console.WriteLine();
        Console.WriteLine("Введите номер товара, который хотите удалить");
        Console.WriteLine();
        int index = int.TryParse(Console.ReadLine(), out int i) ? i : 0;    
        if (index > 0 && index <= items.Count )
        {
            items.RemoveAt(index - 1);
            SaveToFile();
        }
    }

    public void Print()
    {   
        for (int i = 0; i < items.Count; i++)
        {
            var s = items[i];
            Console.WriteLine($"{i + 1}. {s.Name}, Кол-во: {s.Count}, Цена: {s.Price} $");
        }
    }

    private void LoadFromFile()
    {
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); 
            items = JsonSerializer.Deserialize<List<Item>>(json, jsonOptions) ?? new List<Item>();
            Console.WriteLine($"Загружено {items.Count} товаров из файла.");
        }
        else
        {
            Console.WriteLine("Файл не найден. Создаем новый список.");
            
            items = new List<Item>
            {
                new Item("Messi",1,1_000_000),
                new Item("Emir",1,Decimal.MaxValue),
                new Item("Sun",1,Decimal.MaxValue - 1),
            };
            SaveToFile();
        }
    }

    private void SaveToFile()
    {
        string jsonStr = JsonSerializer.Serialize(items,jsonOptions);
        File.WriteAllText(filePath, jsonStr);
    }
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Что вы хотите сделать");
            Console.WriteLine("1 - Добавить товар");
            Console.WriteLine("2 - Удалить товар");
            Console.WriteLine("3 - Вывести товары");
            Console.WriteLine();
            int choice = int.TryParse(Console.ReadLine(), out int i) ? i : 0;
            switch (choice)
            {
                case 1:
                    MyAdd();
                    break;
                case 2:
                    Delete();
                    break;
                case 3:
                    Print();
                    break;
                default:
                    Console.WriteLine("Неверный набранный номер");
                    Console.WriteLine();
                    break;
            }
        }
        


    }
}

public class Item
{
    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public Item(string name, int count, decimal price)
    {
        Name = name;
        Count = count;
        Price = price;
    }
}

