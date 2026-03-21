namespace CW6;

public class Diary
{
    public static void Run()
    {
        var currentDictionary = Directory.GetCurrentDirectory();
        var fileName ="MyDiary.txt";
        var filePath = Path.Combine(currentDictionary, fileName);
        
        if (!File.Exists(filePath)) File.Create(filePath).Close();
        
        var inputStr = Console.ReadLine();
        DateTime time = DateTime.Now;
        var timeFormated = time.ToString("dd:MM:yyyy HH:mm");
        File.AppendAllText(filePath, $" {inputStr} - {timeFormated}");
    }
}