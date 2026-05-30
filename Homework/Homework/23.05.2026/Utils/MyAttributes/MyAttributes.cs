namespace _11507_24.Homework._23._05._2026.Utils.MyAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class MyRequiredAttribute : Attribute
{
    public string ErrorMessage { get; set; } = "Something";
}

[AttributeUsage(AttributeTargets.Property)]
public class MyRangeAttribute : Attribute
{
    public int Min { get; set; }
    public int Max { get; set; }
    public string ErrorMessage { get; set; } = "Something";
    
    public  MyRangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}