namespace AutomatedProcess.Core;

public interface IProcessFactory
{
    IReadOnlyDictionary<string, IProcess> GetAllProcesses();
    IProcess? GetProcess(string name);
    void RegisterProcess(IProcess process);
    void UnregisterProcess(IProcess process);
}
