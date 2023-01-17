using System.Configuration;

namespace AutomatedProcess.Scheduler;

public struct SchedulerConfiguration
{
    public bool WaitForCompletionOnStop {get; set;}
    public List<ScheduledProcess>? ScheduledProcesses {get; set;}
}

public struct ScheduledProcess
{
    public static string ConfigurationName = "ProcessConfiguration";

    public string? Name {get; set;}
    public string? Schedule {get; set;}
    public string? Configuration {get; set;}
    public string? DllPath {get; set;}
    public string? RunProcess {get; set;}
}