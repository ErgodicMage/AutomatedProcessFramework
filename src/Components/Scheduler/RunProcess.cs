namespace AutomatedProcess.Scheduler;

public abstract class RunProcess : StatefulProcess
{
    public override async Task Execute(IJobExecutionContext context)
    {
        await base.Execute(context);
        await Run();
    }

    public abstract Task Run();
}
