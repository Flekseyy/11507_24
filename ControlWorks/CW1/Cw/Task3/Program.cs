using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var currentDirectory = "C:\\Windows";
        var files = Directory.GetFiles(currentDirectory);
        
        var result = files
            .Select(f => new FileInfo(f))
            .Where(fi => fi.Length >= 1024) 
            .GroupBy(fi => fi.Extension)   
            .Select(g => new { Extension = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);
        using (var writer = new StreamWriter("summary.txt"))
        {
            foreach (var item in result)
            {
                writer.WriteLine($"{item.Extension}: {item.Count}");
            }
        }
        
        Console.WriteLine("Результаты залиты в файл");
    }
}
