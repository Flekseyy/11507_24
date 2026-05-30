namespace _11507_24.Homework._14._03._2026._1_4;

public static class EnumerableExtensions
{
    public static void ForEachWithIndex<T>(
        this IEnumerable<T> collection,
        Action<T, int> action)
    {
        int index = 0;
        foreach (var item in collection)
        {
            action(item, index);
            index++;
        }
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         var names = new List<string> { "Андрей", "Валентин", "Ильдар" };
//         
//         names.ForEachWithIndex((name, index) =>
//         {
//             Console.WriteLine($"{index + 1}. {name}");
//         });
//
//         Console.WriteLine();
//         
//         var numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
//         numbers.ForEachWithIndex((number, index) =>
//         {
//             Console.WriteLine($"Элемент [{index + 1 }] = {number}");
//         });
//         
//     }
// }