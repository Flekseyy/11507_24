namespace CW5;

public class ProcessEvent
{
    public static void Run()
    {
        Publisher publisher = new Publisher();
        {
            Subscriber subscriber1 = new Subscriber(publisher);
            subscriber1.DisplayMessage("Сообщение");
        }
        
        Console.WriteLine(publisher);
        Console.WriteLine(GC.GetGeneration(publisher));
        Console.WriteLine(GC.GetTotalMemory(false));
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Console.WriteLine(publisher);
        Console.WriteLine(GC.GetGeneration(publisher));
        Console.WriteLine(GC.GetTotalMemory(false));
        
        Console.WriteLine("-------------------------------По другому-------------------------------");
        Publisher publisher1 = new Publisher();

        using (Subscriber subscriber2 = new Subscriber(publisher1))
        {
            publisher1.GenerateData("Сообщение");
        }
        
        Console.WriteLine(publisher1);
        Console.WriteLine(GC.GetGeneration(publisher1));
        Console.WriteLine(GC.GetTotalMemory(false));
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Console.WriteLine(publisher1);
        Console.WriteLine(GC.GetGeneration(publisher1));
        Console.WriteLine(GC.GetTotalMemory(false));
    }
}