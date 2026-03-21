namespace Delegate.Level_4;

public static class CustomForeach
{
    public static void ForEachWithIndex<T>(this IEnumerable<T> numerable, Action<T,int> action)
    {
        int index = 0;
        foreach (var item in numerable)
        {
            action(item, index);
            index++;
        }
    }
}