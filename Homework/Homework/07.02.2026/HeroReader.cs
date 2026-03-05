using System.Collections;

namespace _11507_24.Homework._07._02._2026;

public class HeroReader
{
    public static IEnumerable<Hero> ReadHeroes(string path)
    {
        using (StreamReader ReaderObject = new StreamReader(path)) {
            
            string Line;
            
            while ((Line = ReaderObject.ReadLine()) != null) 
            { 
                if (string.IsNullOrWhiteSpace(Line)) continue;
                
                Hero hero = Hero.Parse(Line);
                
                if (hero != null) yield return hero;
            }
        }
    }
}