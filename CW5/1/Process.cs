

namespace CW5;

public class Process
{
   
    public static void Run()
    {
        HeavyProject heavyProject = new HeavyProject();
        Console.WriteLine(GC.GetGeneration(heavyProject));
        Console.WriteLine(GC.GetTotalMemory(false));
    
        
        GC.Collect();
        
        Console.WriteLine(GC.GetGeneration(heavyProject));
        Console.WriteLine(GC.GetTotalMemory(false));
        for (int i = 0; i < 100_000; i++)
        {
             new object();
        }
        Console.WriteLine(GC.GetGeneration(heavyProject));
        Console.WriteLine(GC.GetTotalMemory(false));
        // GC.Collect();
        // Console.WriteLine(GC.GetGeneration(heavyProject));
        // Console.WriteLine(GC.GetTotalMemory(true));
    }
}