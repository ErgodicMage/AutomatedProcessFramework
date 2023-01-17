using Basic;

var process = new BasicProcess();

var cancellationToken = new CancellationToken();
await process.Execute(cancellationToken);

