using System.Reflection;

namespace _11507_24.Homework._23._05._2026.Utils.MyMapper;

public class MyMapperImplementation : IMapper
{
    public void Map<TSource, TDest>(TSource source, TDest dest)
    {
        if (source is null || dest is null) return;
        
        var sourceType = typeof(TSource);
        var destType = typeof(TDest);
        
        var sourceProperties = sourceType.GetProperties(
            BindingFlags.Public | BindingFlags.Instance);
        
        var destProperties = destType.GetProperties(
            BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(x => x.Name, x => x);

        foreach (var sourceProperty in sourceProperties)
        {
            if (!sourceProperty.CanRead) continue;
            if (!destProperties.TryGetValue(sourceProperty.Name, out var dstProp)) continue;
            if (!dstProp.CanWrite) continue;
            if (!dstProp.PropertyType.IsAssignableFrom(sourceProperty.PropertyType)) continue;
            
            var value = sourceProperty.GetValue(source);
            
            dstProp.SetValue(dest, value);
        }
    }
}