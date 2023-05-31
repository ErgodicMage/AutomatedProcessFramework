using AutomatedProcess.MinimalProcess;

var process = new MinimalIProcessImpl();

bool result =  await process.Execute();

return result ? 0 : 1;