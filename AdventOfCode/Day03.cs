using System.Text.RegularExpressions;
/// <summary>
/// --- Day 3: Mull It Over ---
/// </summary>
namespace AdventOfCode;

public partial class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{RunProgram()}");

    public override ValueTask<string> Solve_2() => new($"{RunProgram(true)}");

    private int RunProgram(bool EnableSwitches = false)
    {
        var result = 0;
        var enabled = true;
        var instructionSet = CommandRegex().Matches(_input).Select(x => x.ToString());
        foreach (var instruction in instructionSet)
        {
            switch (instruction)
            {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default:
                    if (enabled | !EnableSwitches)
                    {
                        result += instruction.Substring(4, instruction.Length - 5).Split(',')
                          .Aggregate(1, (x, y) => x * int.Parse(y));
                    }
                    break;
            }
        }
        return result;
    }
    [GeneratedRegex(@"don't\(\)|do\(\)|mul\(\d{1,3},\d{1,3}\)")]
    private static partial Regex CommandRegex();
}
