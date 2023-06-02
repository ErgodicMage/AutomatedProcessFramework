using AutomatedProcess.Core;

namespace AutomatedProcess.MinimalProcess;

public class MinimalIProcessImpl : IProcess
{
    public string ProcessName {get; init;} = "Minimal Process";

    public async Task<bool> Run(CancellationToken? cancellationToken = default)
    {
        Console.WriteLine($"Running {ProcessName}");

        int cnt = 0;
        while (cnt < 10)
        {
            Console.WriteLine($"{ProcessName} running at: {DateTime.Now}");
            await Task.Delay(1000, cancellationToken.GetValueOrDefault());
            cnt++;
        }

        Console.WriteLine($"{ProcessName} stopped");

        return true;
    }
}
