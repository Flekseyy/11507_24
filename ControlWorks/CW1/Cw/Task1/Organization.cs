namespace Cw;

public class Company
{
    public string Name { get; set; }
}

public class Worker
{
    public string Name { get; set; }
    public Company Employer { get; set; }
}

public class Organization<T> where T : Worker, new()
{
    
    public T HireReplacement(T oldWorker, Company newCompany)
    {
        return new T
        {
            Name = oldWorker.Name,    
            Employer = newCompany
        };
        
    }
}
