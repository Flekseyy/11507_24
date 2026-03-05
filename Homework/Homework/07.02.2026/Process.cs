namespace _11507_24.Homework._07._02._2026;

public class Process
{
    public static void Run()
    {
        Console.WriteLine("Dota 2 Hero Sorter");
        Console.WriteLine("Введите тип героя на английском (Strength/Agility/Intelligence/Universal)");
        string? filterType = Console.ReadLine()?.Trim();
        Console.WriteLine("Введите сложность (1/2/3)");
        string? complexityInput = Console.ReadLine()?.Trim();
        int.TryParse(complexityInput, out int complexityFilter);
        Console.WriteLine("Введите параметр сортировки (HP/Mana/MoveSpd/Armor/Damage)");
        string? sortParam = Console.ReadLine()?.Trim();
        
        string FileToRead = @"C:\Users\Admin\Desktop\HM\Homework\Homework\07.02.2026\Heroes.txt";
        var stream = HeroReader.ReadHeroes(FileToRead);
        var filteredStream = HeroFilters.FilterHeroes(stream, filterType,complexityFilter);

        List<Hero> heroes = new List<Hero>();
        foreach (var hero in filteredStream)
        {
            heroes.Add(hero);
        }
        if (heroes.Count == 0)
        {
            Console.WriteLine($"Герои типа '{filterType}' не найдены!");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            return;
        }

        switch (sortParam.ToLower())
        {
            case "hp":
                heroes.Sort(CompareByHp);
                break;
            case "mana":
                heroes.Sort(CompareByMana);
                break;
            case "movespd":
                heroes.Sort(CompareByMoveSpd);
                break;
            case "armor":
                heroes.Sort(CompareByArmor);
                break;
            case "damage":
                heroes.Sort(CompareByDamage);
                break;
            default:
                heroes.Sort(CompareByHp);
                break;
        }
        
        Console.WriteLine($"Найдено {heroes.Count} героев ({filterType})");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine($"{hero.Name} | {hero.PrimaryAttr} | {hero.HP} | {hero.Mana} | {hero.MoveSpd} | {hero.Armor}");
        }
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }


    private static int CompareByHp(Hero h1, Hero h2)
    {
        return h1.HP.CompareTo(h2.HP); 
    }
    
    private static int CompareByMana(Hero h1, Hero h2)
    {
        return h1.Mana.CompareTo(h2.Mana);
    }
    
    private static int CompareByMoveSpd(Hero h1, Hero h2)
    {
        return h1.MoveSpd.CompareTo(h2.MoveSpd);
    }
    
    private static int CompareByArmor(Hero h1, Hero h2)
    {
        return h1.Armor.CompareTo(h2.Armor);  
    }
    
    private static int CompareByDamage(Hero h1, Hero h2)
    {
        return h1.Damage.CompareTo(h2.Damage);
    }
}