using System.Diagnostics;
using System.Text;

namespace _11507_24.Homework._11._04._2026;
using System.Security.Cryptography;
public class BigData
{
    // public void CreateFile()
    // {
    //     long Size = 2L * 1024 * 1024* 1024;
    //     int bufferSize = 65536;
    //     byte[] buffer = new byte[bufferSize];
    //     using var sw = new FileStream("BigData.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
    //     using var rng = RandomNumberGenerator.Create();
    //     {
    //         long remaining = Size;
    //         while (remaining > 0)
    //         {
    //             int toWrite = (int)Math.Min(bufferSize, remaining);
    //             rng.GetBytes(buffer, 0, toWrite);
    //             sw.Write(buffer, 0, toWrite);
    //             remaining -= toWrite;
    //         }
    //     }
    // }

    public static void Run()
    {
        var stopwatch = Stopwatch.StartNew();
        byte targetByte = 65;
        int bufferSize = 65536;
        long count = 0;
        byte[] buffer = new byte[bufferSize];
        using (var fs = new FileStream("BigData.txt", FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
        {
            int bytesRead;
            while ((bytesRead = fs.Read(buffer, 0, bufferSize)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    if (targetByte == buffer[i])
                    {
                        count++;
                    }
                }
            }
            
        }
        stopwatch.Stop();
        Console.WriteLine($"Количество символов А - {count}");
        Console.WriteLine($"Время выполнения - {stopwatch.Elapsed.TotalSeconds}");
    }
}