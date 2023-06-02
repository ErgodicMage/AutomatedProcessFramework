namespace AutomatedProcess.Scheduler;

[PersistJobDataAfterExecution]
[DisallowConcurrentExecution]
public class StatefulProcess : IJob
{
    private IJobExecutionContext? _context;
    public IJobExecutionContext? Context {get => _context;}

    public virtual Task Execute(IJobExecutionContext context)
    {
        _context = context;
        return Task.CompletedTask;
    }

    public CancellationToken? CancellationToken() => _context?.CancellationToken;

    public string GetConfigFile() => _context?.JobDetail?.JobDataMap?[ScheduledProcess.ConfigurationName] as string ?? string.Empty;

    public bool HasJobData(string key) => _context?.JobDetail?.JobDataMap?.ContainsKey(key) ?? false;
    
    public object? GetJobData(string key) => _context?.JobDetail?.JobDataMap?[key];

    public T? GetJobData<T>(string key) where T : class => _context?.JobDetail?.JobDataMap?[key] as T ?? default(T);

    public void SetJobData(string key, object obj) => _context?.JobDetail?.JobDataMap?.Put(key, obj);

    public void ClearJobData(string key) => _context?.JobDetail?.JobDataMap?.Remove(key);
}
