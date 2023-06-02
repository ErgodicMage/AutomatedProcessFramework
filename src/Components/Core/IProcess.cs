namespace AutomatedProcess.Core;

public interface IProcess
{
    string ProcessName {get; init;}
    Task<bool> Run(CancellationToken cancellationToken = default);
}