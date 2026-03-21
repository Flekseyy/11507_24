namespace _11507_24.Homework._21._03._2026.LQ3;

public static class MynewLinq
{
    public static IEnumerable<TSource> MyWhere<TSource>(
        this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
    public static int MyCount<TSource>(this IEnumerable<TSource> source)
    {
        int cnt = 0;
        foreach (var _ in source)
        {
            cnt++;
        }
        return cnt;
    }
    public static bool MyAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var element in source)
        {
            if (!predicate(element))
            {
                return false;
            }
        }

        return true;
    }
    public static IEnumerable<SimpleGroup<TKey, TSource>> MyGroupBy<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
    {
        var groups = new Dictionary<TKey, SimpleGroup<TKey, TSource>>();

        foreach (var item in source)
        {
            var key = keySelector(item);

            if (!groups.ContainsKey(key))
                groups[key] = new SimpleGroup<TKey, TSource> { Key = key };

            groups[key].Items.Add(item);
        }

        return groups.Values;
    }
}
public class SimpleGroup<TKey, TElement> :  IEnumerable<TElement>
{
    public TKey Key { get; set; }
    public List<TElement> Items { get; set; } = new List<TElement>();
    public IEnumerator<TElement> GetEnumerator() => Items.GetEnumerator();
    
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
