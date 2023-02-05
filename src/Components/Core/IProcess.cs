namespace AutomatedProcess.Core;

public interface IProcess
{
    string ProcessName {get; init;}
    ValueTask<bool> Execute(CancellationToken cancellationToken = default(CancellationToken));
}