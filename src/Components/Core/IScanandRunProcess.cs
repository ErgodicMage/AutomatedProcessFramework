namespace AutomatedProcess.Core;

public interface IScanandRunProcess
{
        string ProcessName {get; init;}
        Task<bool> Scan(CancellationToken? cancellationToken = default);
        Task<bool> Run(CancellationToken? cancellationToken = default);
}
