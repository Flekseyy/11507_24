namespace _11507_24.Homework._21._03._2026.LQ3;

public class CustomSearch
{
    public static IEnumerable<string> FindValidStrings(IEnumerable<string> strings)
    {

        return strings
            .MyWhere(s => s
                .MyGroupBy(c => c)
                .MyAll(g => g
                    .MyCount() <= 2));
    }
}