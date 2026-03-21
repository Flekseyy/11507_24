namespace CW4;

public static class MyLINQ
{
    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
    {
        foreach (var item in source)
        {
            if (count > 0)
            {
                count--;
                continue;
            }
            yield return item;
        }
    }

    public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
        var set = new HashSet<TSource>();
        foreach (var item in first)
        {
            if (set.Add(item))
                yield return item;
        }
        foreach (var item in second)
        {
            if (set.Add(item))
                yield return item;
        }
    }


    public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> source, int count)
    {
        if (count <= 0) yield break;
        foreach (var item in source)
        {
            yield return item;
            count--;
            if(count == 0)
                yield break;
        }
        
    }

    public static TSource[] MyToArray<TSource>(this IEnumerable<TSource> source)
    {
        var length = source.MyCount();
        int index = 0;
        var array = new TSource[length];
        foreach (var item in source)
        {
            array[index++] = item;
        }
        return array;
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

    
}