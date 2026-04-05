using System.Text;

namespace _11507_24.Homework._11._04._2026;

public class BigData
{
    public static void Run()
    {
        using (var sw = new StreamWriter("BigData.txt"))
        {
            for (long i = 0; i < 2_300_000_000; i++)
            {
                sw.WriteLine(i);
            }
        }
        using (FileStream fstream = File.OpenRead("BigData.txt"))
        {
   
            byte[] buffer = new byte[fstream.Length];
  
            var readBytes =  fstream.Read(buffer, 0, buffer.Length);
            if (readBytes > 0)
            {
                string textFromFile = Encoding.Default.GetString(buffer);
                long count = 0;
                for (int i = 0; i < textFromFile.Length; i++)
                {
                    if (textFromFile[i] == 'A')
                    {
                        count++;
                    }
                }
            }
        }
    }
}