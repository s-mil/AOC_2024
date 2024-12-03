using System.Diagnostics;
using System.Runtime.InteropServices;
using Spectre.Console;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private List<List<int>> _processed = null;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{NumberOfSafeZones()}");

    public override ValueTask<string> Solve_2() => new($"{NumberOfSafeZones(true)}");


    
    private bool IsZoneSafe(List<int> zoneValues)
    {
        bool increasing = false;
        if (zoneValues[1] > zoneValues[0]) { increasing = true; }
        for (int i = 1; i < zoneValues.Count(); i++)
        {
            var testNumber = zoneValues[i] - zoneValues[i - 1];
            if ( Math.Abs(testNumber) > 3 | (increasing & testNumber <= 0) | (!increasing & testNumber >= 0))
            {
                return false;
            }

        }

        return true;
    }


    private bool IsZoneSafeDamper(List<int> zoneValues)
    {
        bool increasing = false;
        if (zoneValues[1] > zoneValues[0]) { increasing = true; }
        
        for (int i = 1; i < zoneValues.Count(); i++)
        {
            var testNumber = zoneValues[i] - zoneValues[i - 1];
            if ( Math.Abs(testNumber) > 3 | (increasing & testNumber <= 0) | (!increasing & testNumber >= 0))
            {
                List<int> blindValuesI = [.. zoneValues];
                List<int> blindValues = [.. zoneValues];
                blindValues.RemoveAt(i-1);
                blindValuesI.RemoveAt(i);
                if (IsZoneSafe(blindValuesI) | IsZoneSafe(blindValues))
                { return true;}
                else return false;
            }

        }

        return true;
    }


    private int NumberOfSafeZones(bool ProblemDampener = false) =>
    {
        _input.Select(AllowReversePInvokeCallsAttribute => IsZoneSafe(Process(report), ProblemDampener)

        return zones.Aggregate(0, (agg, next) =>
        {
            if (IsZoneSafe(next))
            {
                agg++;
                return agg;
            }
            return agg;

        });
    }

    private int ProblemDamperSafeZones()
    {
        var zones = ProcessInput();

        return zones.Aggregate(0, (agg, next) =>
        {
            if (IsZoneSafeDamper(next))
            {
                agg++;
                return agg;
            }
            return agg;
        });
    }
}
