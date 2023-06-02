using AutomatedProcess.Core;
using System.Reflection.Metadata.Ecma335;

namespace AutomatedProcess.MinimalScanandRunProcess;

public class MinimalScanandRunImpl : IScanandRunProcess
{
    public string ProcessName {get; init;} = "Minimal Scan and Run Process";

    public bool ShouldRun {get; set;} = true;

    // If ran last time then don't run again but set to run next scan
    public Task<bool> Scan(CancellationToken? cancellationToken = default)
    {
        Console.WriteLine($"Scan return {ShouldRun}");
        ShouldRun = !ShouldRun;
        return Task.FromResult(!ShouldRun);
    }

    // Run a 5 second process and then set scan to return false so it doesn't run next time. 
    // Scan will set it so that it runs every other time.
    // Yes it is correct that Run will run every 7 seconds (instead of intuitively 5) 5 sec for Run + 1 sec for Scan false and + 1 Scan true.
    public async Task<bool> Run(CancellationToken? cancellationToken = default)
    {
        try
        {
            Console.WriteLine($"{ProcessName} Async running at: {DateTime.Now}");
            await Task.Delay(5000, cancellationToken.GetValueOrDefault());
            ShouldRun = false;
        }
        catch(Exception)
        {
            Console.WriteLine($"{ProcessName} cancelation stopped");
        }
        return true;
    }
}
