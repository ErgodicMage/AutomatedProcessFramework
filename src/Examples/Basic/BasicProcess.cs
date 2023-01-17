using AutomatedProcess.Core;

namespace Basic;

public class BasicProcess : IProcess
{
    public string ProcessName {get; init;} = "Basic Process";

    public async Task<bool> Execute(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Running {ProcessName}");

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"Worker running at: {DateTime.Now}");
            await Task.Delay(1000, cancellationToken);
        }
        return true;
    }
}
