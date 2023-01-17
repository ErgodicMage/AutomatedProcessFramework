using AutomatedProcess.Core;

namespace MinimalScanandRunProcess;

public class MinimalScanandRunImpl : IScanandRunProcess
{
    public string ProcessName {get; init;} = "Minimal Scan and Run Process";

    public bool DoRun {get; set;} = true;

    // If ran last time then don't run again but set to run next scan
    public Task<bool> Scan(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Scan return {DoRun}");
        DoRun = !DoRun;
        return Task.FromResult<bool>(!DoRun);
    }

    // Run a 5 second process and then set scan to return false so it doesn't run next time. 
    // Scan will set it so that it runs every other time.
    // Yes it is correct that Run will run every 7 seconds (instead of intuitively 5) 5 sec for Run + 1 sec for Scan false and + 1 Scan true.
    public async Task<bool> Run(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Running {ProcessName}");

        try
        {
            Console.WriteLine($"{ProcessName} running at: {DateTime.Now}");
            await Task.Delay(5000, cancellationToken);
            DoRun = false;
        }
        catch(Exception)
        {
            Console.WriteLine($"{ProcessName} stopped");
        }
        return true;
    }
}
