namespace Delegate.Level_3;

public class Run3
{
    public static void ToRun()
    {
        var user = new User("Данил Колбасенко", "DanilKolbasemko@mail.ru");

        IHandler handler = new EmailHandler();
        handler.SetNext(new DatabaseHandler())
            .SetNext(new StatisticsHandler());
        handler.Handle(user);
    }
}