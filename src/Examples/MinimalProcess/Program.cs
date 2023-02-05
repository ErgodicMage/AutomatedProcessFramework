using AutomatedProcess.MinimalProcess;

var process = new MinimalIProcessImpl();

return process.Execute().GetAwaiter().GetResult() ? 0 : 1;
