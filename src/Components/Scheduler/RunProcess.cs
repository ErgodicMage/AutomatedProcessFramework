namespace AutomatedProcess.Scheduler;

public abstract class RunProcess : StatefulProcess, IProcess
{
    public string ProcessName { get; init; }

    public RunProcess(string processName) => ProcessName = processName;

    public override async Task Execute(IJobExecutionContext context)
    {
        await base.Execute(context);
        await Run(CancellationToken());
    }

    public abstract Task<bool> Run(CancellationToken? cancellationToken = default);
}
