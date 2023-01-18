using AutomatedProcess.Core;

namespace AutomatedProcess.MinimalProcess;

public class MinimalIProcessImpl : IProcess
{
    public string ProcessName {get; init;} = "Minimal Process";

    public MinimalIProcessImpl() {}

    public async Task<bool> Execute(CancellationToken cancellationToken = default(CancellationToken))
    {
        Console.WriteLine($"Running {ProcessName}");

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"{ProcessName} running at: {DateTime.Now}");
                await Task.Delay(1000, cancellationToken);
            }
        }
        catch
        {
            Console.WriteLine($"{ProcessName} stopped");
        }
        return true;
    }
}
