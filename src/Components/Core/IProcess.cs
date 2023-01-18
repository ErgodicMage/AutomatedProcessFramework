namespace AutomatedProcess.Core;

public interface IProcess
{
    string ProcessName {get; init;}
    Task<bool> Execute(CancellationToken cancellationToken = default(CancellationToken));
}