namespace cw2.Task2;
// (7 баллов) Напишите TaskQueueManager: создайте Queue<Action> и два потока. 
// Первый поток (Producer) закидывает в очередь 20 действий, второй (Consumer) забирает их из очереди и выполняет 
// (Для понимания когда остановиться, сделайте у каждого из потоков свой счетчик и перед запуском передавайте количество объектов,
//  которые он должен обработать). Очередь должна быть потокобезопасной.
public class TaskQueueManager
{
    private readonly int _producerCount;
    private readonly int _consumerCount;
    Queue<Action> queue = new Queue<Action>();
    private void Producer(Action action)
    {
        lock (queue)
        {
            
        }
    }

    private void Consumer(Action action)
    {
        lock (queue)
        {
            
        }
    }
}