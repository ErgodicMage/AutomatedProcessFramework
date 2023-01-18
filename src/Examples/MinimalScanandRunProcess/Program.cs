using AutomatedProcess.MinimalScanandRunProcess;

var process = new MinimalScanandRunImpl();
int cnt = 0;
while (cnt < 5)
{
    if (await process.Scan())
        await process.Run();
    await Task.Delay(1000);
    cnt++;
}


Console.WriteLine("You didn't force a stop so continue with a better method of stopping");

// the above process can be stopped ineligently (sp?) with a ctrl-c
// which will stop the entire console application.
// Instead we can stop the process with ctrl-c without stopping the console application.
using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Stopping...");
    cts.Cancel(false);
    e.Cancel = true;
};

var interuptableProcess = new MinimalScanandRunImpl();

try
{
    while (!cts.Token.IsCancellationRequested)
    {
        if (await interuptableProcess.Scan(cts.Token))
            await interuptableProcess.Run(cts.Token);
        if (!cts.Token.IsCancellationRequested)
            await Task.Delay(1000, cts.Token);
    }
}
catch
{
    // at this point I'm not sure why this is being caught
    Console.WriteLine($"{interuptableProcess.ProcessName} stopped");
}

Console.WriteLine("If you see this, the console application gracefully stopped gracefully");

