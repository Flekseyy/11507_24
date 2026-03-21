namespace Delegate.Level_3;

public interface IHandler
{
    void Handle(User user);
    IHandler SetNext(IHandler handler);
}

public abstract class BaseHandler : IHandler
{
    private IHandler _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }
    
    public virtual void Handle(User user)
    {
        try
        {
            HandleInternal(user);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {GetType().Name}: {ex.Message}");
            Console.ResetColor();
        }
        _nextHandler?.Handle(user);
    }
    protected abstract void HandleInternal(User user);
} 

public class EmailHandler : BaseHandler
{
    protected override void HandleInternal(User user)
    {
        Console.WriteLine($"[Email] Отправка на {user.Email}");
    }
}

public class DatabaseHandler : BaseHandler
{
    protected override void HandleInternal(User user)
    {
        Console.WriteLine($"[Database] Сохранение {user.Name}");
    }
}

public class StatisticsHandler : BaseHandler
{
    protected override void HandleInternal(User user)
    {
        Console.WriteLine("[Statistics] Обновление статистики");
    }
}