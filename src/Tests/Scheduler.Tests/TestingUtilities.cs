﻿namespace Scheduler.Tests;

public class TestCategories
{
    public const string UnitTest = "UnitTest";
    public const string IntegrationTest = "IntegrationTest";
    public const string EndToEndTest = "EndToEndTest";
}

public static class TestingUtilities
{
    public static string TestNamespace { get; set; } = "Scheduler.Tests";


    public static string ReadResource(string folder, string resourcefile)
    {
        string filename = folder.Replace(" ", "_").Replace("\\", ".").Replace("/", ".") + "." + resourcefile;
        return ReadResource(filename);
    }

    public static string ReadResource(string resourcefile)
    {
        string filename = TestNamespace + "." + resourcefile;

        string retString = string.Empty;
        using (StreamReader reader = LoadResourceFile(filename))
        {
            retString = reader.ReadToEnd();
        }

        return retString;
    }

    public static StreamReader LoadResourceFile(string resourcefile)
    {
        StreamReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcefile)!);
        return reader;
    }
}
