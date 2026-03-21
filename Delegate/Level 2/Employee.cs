namespace Delegate.Level_2;

public class Employee
{
    public string Name{get; private set;}
    public int Salary{get; private set;}
    public int Experience{get; private set;}

    public Employee(string name, int salary, int experience)
    {
        Name = name;
        Salary = salary;
        Experience = experience;
    }
    
    public override string ToString()
    {
        return $"Имя: {Name}, Зарплата: {Salary}, Стаж: {Experience} лет";
    }
    
    public static void FilterEmployees(List<Employee> employees, Predicate<Employee> filter)
    {
        foreach (var employee in employees)
        {
            if (filter(employee))
            {
                Console.WriteLine(employee);
            }
        }
    }
}