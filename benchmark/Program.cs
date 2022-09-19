using System;
using System.Diagnostics;
using System.Linq;
using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;

var dir = Directory.GetCurrentDirectory();

var toBench = Directory.GetFiles(Path.Combine(dir, "to-bench"));
var datasets = Directory.GetDirectories(Path.Combine(dir, "datasets"));


foreach(var dataset in datasets.OrderBy(x => x))
{
    var peopleNb =  File.ReadLines(Path.Combine(dataset, "people.txt"))
        .LongCount()
        .Humanize();

    var friendshipNb =  File.ReadLines(Path.Combine(dataset, "friendship.txt"))
        .LongCount()
        .Humanize();

    var searches = File.ReadLines(Path.Combine(dataset, "search.txt"));

    var datasetName = Path.GetFileName(dataset).Substring(2);
    var datasetNumbers = $"({peopleNb} entries, {friendshipNb} nodes)";
    Console.WriteLine($"Dataset: {datasetName} {datasetNumbers}");

    var table = new Table("Run", "Duration", "CPU time", "Memory", "A/E");
    table.Config = TableConfig.Unicode();

    foreach(var exe in toBench)
    {
        if (exe.EndsWith(".git-keep")) {
            continue;
        }

        var runs = new List<Run>();
        var i = 1;

        foreach(var search in searches)
        {
            var (first, second, expected) = search.Split(':');

            var process = new Process();
            process.StartInfo.WorkingDirectory = dataset;
            process.StartInfo.FileName = exe;
            process.StartInfo.Arguments = $"\"{first}\" \"{second}\"";
            process.StartInfo.RedirectStandardOutput = true;
            var memory = 0L;
            var cpuTime = default(TimeSpan);

            var startTime = DateTime.Now;
            process.Start();

            try {
                startTime = process.StartTime;
                while(!process.HasExited)
                {
                    cpuTime = process.TotalProcessorTime;
                    memory = Math.Max(process.WorkingSet64, memory);
                    Thread.Sleep(1);
                }
            } catch (Exception ex) {
            }

            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd().Trim();

            var isExpected = output == expected;
            runs.Add(
                new Run(
                    process.ExitTime - startTime,
                    cpuTime,
                    memory, 
                    isExpected
                ));

            i++;
        }

        table.AddRow(
            Path.GetFileNameWithoutExtension(exe), 
            TimeSpan.FromTicks((long) runs.Average(r => r.Duration.Ticks)).Humanize(),
            TimeSpan.FromTicks((long) runs.Average(r => r.Cpu.Ticks)).Humanize(),
            runs.Average(r => r.Memory).Humanize("B"), 
            string.Join(' ', runs.Select(r => r.ExpectedResult ? "✓" : "✗")) 
        );
    }

    Console.WriteLine(table.ToString());
}


public record Run(
    TimeSpan Duration, 
    TimeSpan Cpu, 
    float Memory, 
    bool ExpectedResult
);
