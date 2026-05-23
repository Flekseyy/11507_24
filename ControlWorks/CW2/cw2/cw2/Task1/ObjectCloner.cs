namespace cw2.Task1;

public static class ObjectCloner
{
    
    public static object Clone(object obj)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        
        var type = obj.GetType();
        var clone = Activator.CreateInstance(type);

        foreach (var prop in type.GetProperties())
        {
            prop.SetValue(clone, prop.GetValue(obj));
        }
        return clone;
    }
}