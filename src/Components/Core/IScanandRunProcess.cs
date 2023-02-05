namespace AutomatedProcess.Core;

public interface IScanandRunProcess
{
        string ProcessName {get; init;}
        ValueTask<bool> Scan(CancellationToken cancellationToken = default(CancellationToken));
        ValueTask<bool> Run(CancellationToken cancellationToken = default(CancellationToken));
}
