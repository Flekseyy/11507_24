namespace _11507_24.Homework._07._02._2026;

public class HeroFilters
{
    public static IEnumerable<Hero> FilterHeroes(IEnumerable<Hero> source, string filterType,int complexityFilter)
    {
        foreach (Hero hero in source)
        {
            bool typeMatch =  hero.PrimaryAttr.ToLower() == filterType.ToLower();
            bool complexityMatch = hero.Complexity == complexityFilter;
            if (typeMatch && complexityMatch)
                yield return hero;
        }
    }
}