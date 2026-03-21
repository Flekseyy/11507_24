namespace Delegate.Level_2;

public class Run2
{
    public static void ToRun()
    {
        var employees = new List<Employee>
        {
            new Employee("Зубенко Михаил Петрович", 200_000, 10),
            new Employee("Петров Петр Петрович", 80_000, 7),
            new Employee("Сидоров Сидор Сидорович", 45_000, 3),
            new Employee("Козлов Илья Максимович", 60_000, 6),
            new Employee("Новичков Нович Новичкович", 30_000, 1),
            new Employee("Опытный Опыт Опытнычев", 120_000, 15)
        };
        Console.WriteLine("Все сотрудники с зарплатой более 50_000");
        Employee.FilterEmployees(employees, x => x.Salary > 50_000 );

        Console.WriteLine("Все сотрудники со стажем более 5 лет");
        Employee.FilterEmployees(employees, x => x.Salary > 50_000 );
    }
}