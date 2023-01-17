namespace AutomatedProcess.Scheduler;

public interface IScheduler
{
    Task Start(CancellationToken cancellationToken = default);

    Task Stop(CancellationToken cancellationToken = default);
}