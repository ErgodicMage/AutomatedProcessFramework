namespace AutomatedProcess.Scheduler;

public abstract class ScanandRunProcess : StatefulProcess
{
    public override async Task Execute(IJobExecutionContext context)
    {
        await base.Execute(context);
        if (await Scan())
            await Run();
    }

    public abstract Task<bool> Scan();
    public abstract Task Run();
}
