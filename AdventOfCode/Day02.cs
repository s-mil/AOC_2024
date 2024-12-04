using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Spectre.Console;

namespace AdventOfCode;
/// <summary>
/// --- Day 2: Red-Nosed Reports ---
/// </summary>
public class Day02 : BaseDay
{
    private readonly IEnumerable<string> _input;

    public Day02()
    {
        _input = File.ReadLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{NumberOfSafeZones()}");

    public override ValueTask<string> Solve_2() => new($"{NumberOfSafeZones(true)}");


/// <summary>
/// Process an array of numbers (A report to determine if it follows the rules)
/// </summary>
/// <param name="report"></param>
/// <param name="problemDampener">If set, then ignore one potential problematic value in a report</param>
/// <returns>True if safe</returns>
    private bool IsZoneSafe(int[] report, bool problemDampener = false)
    {
        var initDirection = int.Sign(report[1] - report[0]);

        for (var i = 0; i < report.Length - 1; i++)
        {
            var testValue = report[i + 1] - report[i];
            var dir = int.Sign(testValue);

            if (dir != 0 && dir == initDirection && 1 <= Math.Abs(testValue) && Math.Abs(testValue) <= 3)
                continue;

            return problemDampener && 
            (IsZoneSafe(report.Where((_, idx) => idx != i).ToArray()) || IsZoneSafe(report.Where((_, idx) => idx != i + 1).ToArray()));
        }
        return true;
    }

    private int NumberOfSafeZones(bool problemDampener = false) => 
        _input.Select(report => IsZoneSafe(Process(report), problemDampener))
        .Count(isSafe => isSafe);

    private static int[] Process(string report) => report.Split(' ').Select(int.Parse).ToArray();
}
