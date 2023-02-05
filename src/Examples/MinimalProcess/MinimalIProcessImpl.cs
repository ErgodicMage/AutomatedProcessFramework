using AutomatedProcess.Core;
using System.Runtime.Intrinsics.X86;

namespace AutomatedProcess.MinimalProcess;

public class MinimalIProcessImpl : IProcess
{
    public string ProcessName {get; init;} = "Minimal Process";

    public ValueTask<bool> Execute(CancellationToken cancellationToken = default)
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

        return new ValueTask<bool>(true);
    }
}
