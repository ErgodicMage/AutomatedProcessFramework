namespace AutomatedProcess.Core;

public interface IScanandRunProcess
{
        string ProcessName {get; init;}
        Task<bool> Scan(CancellationToken cancellationToken);
        Task<bool> Run(CancellationToken cancellationToken);
}
