using MinimalProcess;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Stopping...");
    cts.Cancel(false);
    e.Cancel = true;
};

var process = new MinimalIProcessImpl();

return await process.Execute(cts.Token) ? 0 : 1;
