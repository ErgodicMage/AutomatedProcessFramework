using AutomatedProcess.Core;
using System.Reflection.Metadata.Ecma335;

namespace AutomatedProcess.MinimalScanandRunProcess;

public class MinimalScanandRunImpl : IScanandRunProcess
{
    private readonly bool _useAsync;

    public MinimalScanandRunImpl(bool useAsync = false)
    {
        _useAsync = useAsync;
    }

    public string ProcessName {get; init;} = "Minimal Scan and Run Process";

    public bool ShouldRun {get; set;} = true;

    // If ran last time then don't run again but set to run next scan
    public ValueTask<bool> Scan(CancellationToken cancellationToken = default(CancellationToken))
    {
        Console.WriteLine($"Scan return {ShouldRun}");
        ShouldRun = !ShouldRun;
        return new ValueTask<bool>(!ShouldRun);
    }

    // Run a 5 second process and then set scan to return false so it doesn't run next time. 
    // Scan will set it so that it runs every other time.
    // Yes it is correct that Run will run every 7 seconds (instead of intuitively 5) 5 sec for Run + 1 sec for Scan false and + 1 Scan true.
    public async ValueTask<bool> Run(CancellationToken cancellationToken = default(CancellationToken))
        => _useAsync switch
        {
            true => await DoRunAsync(cancellationToken),
            false => DoRun()
        };

    public bool DoRun()
    {
        Console.WriteLine($"{ProcessName} running at: {DateTime.Now}");
        Thread.Sleep(5000);
        ShouldRun = false;
        return true;
    }

    // Asynchronous version with CancellationToken
    public async ValueTask<bool> DoRunAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            Console.WriteLine($"{ProcessName} Async running at: {DateTime.Now}");
            await Task.Delay(5000, cancellationToken);
            ShouldRun = false;
        }
        catch(Exception)
        {
            Console.WriteLine($"{ProcessName} gracefully stopped");
        }
        return true;
    }
}
