using AutomatedProcess.MinimalProcess;

var process = new MinimalIProcessImpl();

return await process.Execute() ? 0 : 1;
