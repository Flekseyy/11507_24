namespace _11507_24.Homework._14._03._2026._1_4;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class NotificationService
{
    public static void SendEmail(User user)
    {
        Console.WriteLine($"Отправка Email - {user.Email} пользователю {user.Name}");
    }
    
    public static void SaveToDatabase(User user)
    {
        Console.WriteLine($"Сохранение данных пользователя {user.Name} в БД");
    }
    
    public static void UpdateStatistics(User user)
    {
        Console.WriteLine($"Обновление статистики для пользователя {user.Name}");
       
        if (user.Name == "")
            throw new Exception("Ошибка при обновлении статистики!");
    }
    
    public static void ProcessUserRegistration(User user)
    {
        Action<User> notificationChain = SendEmail;
        notificationChain += SaveToDatabase;
        notificationChain += UpdateStatistics;
        
        foreach (Action<User> handler in notificationChain.GetInvocationList())
        {
            try
            {
                handler(user);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка в методе {handler.Method.Name} - {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Регистрация одного пользователя");
//         var user1 = new User("Иван", "ivan@gmail.com");
//         NotificationService.ProcessUserRegistration(user1);
//
//         Console.WriteLine("\nРегистрация пользователя с ошибкой ");
//         var user2 = new User("", "error@example.com");
//         NotificationService.ProcessUserRegistration(user2);
//     }
// }