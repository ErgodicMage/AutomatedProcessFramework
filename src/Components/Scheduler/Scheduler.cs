using Microsoft.Extensions.Logging;
using Quartz.Impl;
using System.Text.Json;

namespace AutomatedProcess.Scheduler;

public sealed class Scheduler : IScheduler
{
    private readonly ILogger<Scheduler>? _logger;
    private readonly SchedulerConfiguration _configuration;
    private Quartz.IScheduler? _scheduler;

    public Scheduler(string configFileName) =>_configuration = LoadConfigruation(configFileName);
    public Scheduler(SchedulerConfiguration configuration) => _configuration = configuration;

    public Scheduler(ILogger<Scheduler> logger, SchedulerConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public Scheduler(ILogger<Scheduler> logger, string configFileName)
    {
        _logger = logger;
        _configuration = LoadConfigruation(configFileName);;
    }

    private SchedulerConfiguration LoadConfigruation(string configFileName)
    {
        ArgumentNullException.ThrowIfNull(nameof(configFileName));
        SchedulerConfiguration config;
        try
        {
            using var configFile = File.OpenRead(configFileName);
            config = JsonSerializer.Deserialize<SchedulerConfiguration>(configFile)!;
        }
        catch (Exception ex)
        {
            _logger?.LogCritical(ex, "Can not load configuration file {filename}", configFileName);
            throw;
        }
        return config;
    }

    public async Task Start(CancellationToken cancellationToken = default)
    {
        if (_configuration.ScheduledProcesses is null) 
            throw new NullReferenceException("Scheduler is not configured");

        try
        {
            _logger?.LogTrace("Starting Scheduler");
            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = await schedulerFactory.GetScheduler(cancellationToken);

            await _scheduler.Start();

            await Startup(cancellationToken);

            _logger?.LogInformation("Scheduler started");
        }
        catch (Exception ex)
        {
            _logger?.LogCritical(ex, "Can not start Scheduler");
            throw;
        }
    }

    public async Task Stop(CancellationToken cancellationToken = default)
    {
        try
        {
            _logger?.LogDebug("Stopping Scheduler");
            await _scheduler?.Shutdown(_configuration.WaitForCompletionOnStop, cancellationToken)!;
            _scheduler = null;
            _logger?.LogInformation("Scheduler stopped");
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Can not stop Scheduler");
        }
    }

    private async Task Startup(CancellationToken cancellationToken = default)
    {
        foreach (ScheduledProcess process in _configuration.ScheduledProcesses!)
        {
            IJobDetail job = GetJobDetail(process);
            ITrigger trigger = GetJobTrigger(process, job);

            await _scheduler!.ScheduleJob(job, trigger, cancellationToken);

            _logger?.LogInformation("{processname} scheduled", process.Name);
        }
    }


    private string GroupName(ScheduledProcess process) => $"AutomatedProcess.Scheduler.{process.Name}";

    private IJobDetail GetJobDetail(ScheduledProcess process)
    {
        Type type = GetType(process.RunProcess!);

        IJobDetail job = JobBuilder.Create()
            .WithIdentity(process.Name!, GroupName(process))
            .OfType(type)
            .Build();

        job.JobDataMap.Put(ScheduledProcess.ConfigurationName, process.Configuration);

        return job;
    }

    private ITrigger GetJobTrigger(ScheduledProcess process, IJobDetail job)
    {
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(GroupName(process))
            .WithCronSchedule(process.Schedule!)
            .ForJob(job)
            .Build();

        return trigger;
    }

    private Type GetType(string typename)
    {
        var type = Type.GetType(typename);
        if (type is null)
        {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typename);
                if (type is not null)
                    break;
            }
        }

        if (type is null)
            throw new Exception($"Scheduler can not find {typename}");

        return type;
    }
}
