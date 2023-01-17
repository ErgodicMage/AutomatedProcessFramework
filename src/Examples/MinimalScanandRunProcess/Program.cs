using MinimalScanandRunProcess;;

using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Stopping...");
    cts.Cancel(false);
    e.Cancel = true;
};

var process = new MinimalScanandRunImpl();

try
{
    while (!cts.Token.IsCancellationRequested)
    {
        if (await process.Scan(cts.Token))
            await process.Run(cts.Token);
        if (!cts.Token.IsCancellationRequested)
            await Task.Delay(1000, cts.Token);
    }
}
catch
{
    // at this point I'm not sure why this is being caught
    Console.WriteLine($"{process.ProcessName} stopped");
}



return 0;

