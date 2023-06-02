namespace AutomatedProcess.Scheduler;

public abstract class ScanandRunProcess : StatefulProcess, IScanandRunProcess
{
    public string ProcessName { get; init; }

    public ScanandRunProcess(string processName) => ProcessName = processName;

    public override async Task Execute(IJobExecutionContext context)
    {
        await base.Execute(context);
        if (await Scan(CancellationToken()))
            await Run(CancellationToken());
    }

    public abstract Task<bool> Scan(CancellationToken? cancellationToken = default);
    public abstract Task<bool> Run(CancellationToken? cancellationToken = default);
}
