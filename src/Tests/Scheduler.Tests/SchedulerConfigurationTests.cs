namespace Scheduler.Tests;

public class SchedulerConfigurationTests
{
    private readonly ITestOutputHelper _output;

    public SchedulerConfigurationTests(ITestOutputHelper output) => _output = output;

    [Fact]
    [Trait("Category", TestCategories.UnitTest)]
    public void DeserializeJsonConfiguration()
    {
        string json = TestingUtilities.ReadResource("TestFiles", "SimpleSchedulerConfiguration.json");
        var config = JsonSerializer.Deserialize<SchedulerConfiguration>(json);

        Assert.NotNull(config.ScheduledProcesses);
        Assert.False(config.WaitForCompletionOnStop);
        Assert.Equal(2, config.ScheduledProcesses.Count);
    }

    [Fact]
    [Trait("Category", TestCategories.UnitTest)]
    public void SerializeJsonConfiguration()
    {
        var config = new SchedulerConfiguration();
        config.ScheduledProcesses = new List<ScheduledProcess>();
        var process = new ScheduledProcess()
        {
            Name = "SimpleRunProcess",
            Schedule = "0 1 * * * *",
            Configuration = "RunProcessConfiguration.json",
            RunProcess = "Scheduler.Tests.SimpleRunProcess"
        };
        config.ScheduledProcesses.Add(process);
        process = new ScheduledProcess()
        {
            Name = "SimpleScanandRunProcess",
            Schedule = "0 1 * * * *",
            Configuration = "RunProcessConfiguration.json",
            RunProcess = "Scheduler.Tests.SimpleScananRunProcess"
        };
        config.ScheduledProcesses.Add(process);
        string json = JsonSerializer.Serialize<SchedulerConfiguration>(config, new JsonSerializerOptions(){WriteIndented =true});

    }
}