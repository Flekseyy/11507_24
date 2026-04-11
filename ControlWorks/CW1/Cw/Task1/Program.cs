using Cw;

public class Program
{
    public static void Main()
    {
        Company Alpha = new Company
        {
            Name = "Alpha",
        };
        Engineer engineerAlpha =  new Engineer
        {
            Name = "Вася",
            Employer = Alpha
        };
        Company Beta = new Company
        {
            Name = "Beta",
        };
        Organization<Engineer>  betaorg =  new Organization<Engineer>();
        var engineerBeta = betaorg.HireReplacement(engineerAlpha,Beta);
        
        Console.WriteLine($"Имя инженера Альфы {engineerAlpha.Name}");
        Console.WriteLine($"Компания {engineerAlpha.Employer.Name}");
        Console.WriteLine($"Имя инженера Беты {engineerBeta.Name}");
        Console.WriteLine($"Компания {engineerBeta.Employer.Name}");
    }
}

public class Engineer : Worker
{
}
