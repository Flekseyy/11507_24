namespace _11507_24.Homework._21._03._2026.LQ3;

public class SearchPr
{
    public static void Run()
    {
        var strings = new[]
        {
            "12345678987654321234567890987654323456789098765432",
            "1234",
            "12345",
            "AvbBSFfs"
            
        };
        var validString = CustomSearch.FindValidStrings(strings);
        Console.WriteLine("Найденные строки");
        int cnt = 1;
        foreach (var str in validString)
        {
            Console.WriteLine($"{cnt++}: {str}");
        }
    }
}