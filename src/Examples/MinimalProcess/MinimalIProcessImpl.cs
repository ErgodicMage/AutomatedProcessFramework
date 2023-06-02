using AutomatedProcess.Core;

namespace AutomatedProcess.MinimalProcess;

public class MinimalIProcessImpl : IProcess
{
    public string ProcessName {get; init;} = "Minimal Process";

    public Task<bool> Execute(CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Running {ProcessName}");

        int cnt = 0;
        while (cnt < 10)
        {
            Console.WriteLine($"{ProcessName} running at: {DateTime.Now}");
            Thread.Sleep(1000);
            cnt++;
        }

        Console.WriteLine($"{ProcessName} stopped");

        return Task.FromResult(true);
    }
}
