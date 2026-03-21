using CW4;

public class LinqPr
{
    public static void Run()
    {
        int[] massive = new int[] {1,2,3,4,5,6,7,8,9 }; 
        var aftermas = MoveLeft(massive, 1);
        Console.WriteLine(string.Join(", ", aftermas));
    }

    public static int[] MoveLeft(int[] source, int step)
    {
        if (source.Length == 0  || step == 0)  return source;
        
        step %= source.Length;
        
        if(step == 0) return source;
        
        return source.MySkip(step)
            .MyUnion(source.MyTake(step))
            .MyToArray();
    }
}