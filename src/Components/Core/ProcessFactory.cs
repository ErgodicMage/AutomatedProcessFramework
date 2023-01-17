using System.Collections.ObjectModel;

namespace AutomatedProcess.Core;

public class ProcessFactory : IProcessFactory
{
    private readonly IDictionary<string, IProcess> _processes;
    public ProcessFactory()
    {
        _processes = new Dictionary<string, IProcess>();
    }

    public void RegisterProcess(IProcess process)
    {
        if (process is not null && !_processes.ContainsKey(process.ProcessName))
            _processes.Add(process.ProcessName, process);
    }

    public void UnregisterProcess(IProcess process)
    {
        if (process is not null && _processes.ContainsKey(process.ProcessName))
            _processes.Remove(process.ProcessName);
    }

    public IProcess? GetProcess(string name)
        => _processes.FirstOrDefault(kvp => kvp.Key == name).Value;

    public IReadOnlyDictionary<string, IProcess> GetAllProcesses()
        => new ReadOnlyDictionary<string, IProcess>(_processes);
}
