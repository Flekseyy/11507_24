using System.Globalization;

namespace Delegate.Level_4;

public class Run4
{
    public static void Run()
    {
        var list = new List<string>
        {
            "Алексей","Артём","Эмир","Мердан"
        };
        Console.WriteLine("Печать имён");
        list.ForEachWithIndex((name, index) =>
        {
            Console.WriteLine($"{index + 1}. {name}");
        });
    }
}