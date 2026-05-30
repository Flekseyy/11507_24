namespace _11507_24.Homework._14._03._2026._1_4;

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int ExperienceYears { get; set; }

    public Employee(string name, decimal salary, int experience)
    {
        Name = name;
        Salary = salary;
        ExperienceYears = experience;
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Зарплата: {Salary}, Стаж: {ExperienceYears} лет";
    }
}

public class EmployeeFilter
{
    public static List<Employee> FilterEmployees(
        List<Employee> employees, 
        Predicate<Employee> filter)
    {
        var result = new List<Employee>();
        foreach (var emp in employees)
        {
            if (filter(emp))
            {
                result.Add(emp);
            }
        }
        return result;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         var employees = new List<Employee>
//         {
//             new ("Иван", 80_000, 3),
//             new ("Петр", 145_000, 7),
//             new ("Анна", 275_000, 10),
//             new ("Мария", 100_000, 5),
//             new ("Сергей", 60_000, 2)
//         };
//
//         Console.WriteLine("Все сотрудники");
//         Console.WriteLine();
//         foreach (var emp in employees)
//             Console.WriteLine(emp);
//         
//         Console.WriteLine();
//         Console.WriteLine("Сотрудники с зарплатой больше 50_000");
//         Console.WriteLine();
//         var highSalary = EmployeeFilter.FilterEmployees(
//             employees, 
//             e => e.Salary > 50000
//         );
//         foreach (var emp in highSalary)
//             Console.WriteLine(emp);
//         
//         Console.WriteLine();
//         Console.WriteLine("Сотрудники со стажем больше 5 лет");
//         Console.WriteLine();
//         var experienced = EmployeeFilter.FilterEmployees(
//             employees,
//             e => e.ExperienceYears > 5
//         );
//         foreach (var emp in experienced)
//             Console.WriteLine(emp);
//     }
// }