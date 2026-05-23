using cw2.Task1;
public class Program
{
    public static void Main()
    {
        var user = new object();
        var user2 = ObjectCloner.Clone(user);
    }
}