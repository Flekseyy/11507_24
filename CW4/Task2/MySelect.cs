namespace CW4.Task2;

public static class MySelector
{
    public static IEnumerable<R> MySelectMany<T, R>(this IEnumerable<T> source, Func<T, IEnumerable<R>> selector)
    {
        foreach (var item in source)
        {
            foreach (var subItem in selector(item))
            {
                yield return subItem;
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

    public static IEnumerable<TResult> MySelect<TSource, TResult>(
        this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }
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

    public static bool MyContains<TSource>(this IEnumerable<TSource> source, 
        TSource value, IEqualityComparer<TSource>? comparer = null)
    {
        foreach (var item in source)
        {
            if (comparer != null)
            {
                if (comparer.Equals(item, value))
                    return true;
            }
            else
            {
                if (item?.Equals(value) == true)
                    return true;
            }
        }
        return false;
    }

    public static IEnumerable<TSource> MyDistinct<TSource>(
        this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer = null)
    {
        var seen = new HashSet<TSource>(); 
        foreach (var item in source)
        {
            if (!seen.MyContains(item, comparer))
            {
                seen.Add(item);
                yield return item;
            }
        }
    }
}