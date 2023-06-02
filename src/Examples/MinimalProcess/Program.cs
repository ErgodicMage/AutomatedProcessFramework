using AutomatedProcess.MinimalProcess;

var process = new MinimalIProcessImpl();

bool result =  await process.Run();

return result ? 0 : 1;