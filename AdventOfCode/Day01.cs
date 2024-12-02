using System.ComponentModel;
using Spectre.Console;

namespace AdventOfCode;

/// <summary>
/// Historian Hysteria
/// </summary>
public class Day01 : BaseDay
{
    /// <summary>
    /// The input
    /// </summary>
    private readonly string _input;
    private (List<int>, List<int>)? _processed = null;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        // _input = "3   4\n4   3\n2   5\n1   3\n3   9\n3   3";
    }

    public override ValueTask<string> Solve_1() => new($"{SumAllDistances()}");
    public override ValueTask<string> Solve_2() => new($"{FindSimilarityScore()}");

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The sum distance between items</returns>
    private int SumAllDistances()
    {
        var (list1, list2) = ProcessInput();

        var result = 0;

        for (var i = 0; i < list1.Count; i++)
        {
            result += Math.Abs(list1[i] - list2[i]);
        }

        return result;

    }

    private int FindSimilarityScore()
    {
        var (list1, list2) = ProcessInput();

    
        var SimScore = list2
            .GroupBy(i => i )
            .ToDictionary (g => g.Key , g=> g.Count());




        return list1.Aggregate(0, (agg, next) => agg + next * SimScore.GetValueOrDefault(next));




    }

    /// <summary>
    /// Process the input into two sorted lists
    /// </summary>
    /// <param name="ProcessInput("></param>
    /// <returns>A tuple of lists</returns>
    private (List<int>, List<int>) ProcessInput()
    {
        if (_processed is not null) return _processed.Value;

        var initial = (new List<int>(), new List<int>());
        Console.WriteLine(_input.Split("\n"));
        var lists = (new List<int>(), new List<int>());

        lists = _input
            .Split("\n")
            .Select(x => x.Split("   "))
            .Aggregate(initial, (agg, next) =>
            {
                if (next[0] != "" && next[1] != "")
                {
                    agg.Item1.Add(int.Parse(next[0]));
                    agg.Item2.Add(int.Parse(next[1]));
                    return agg;
                }
                return agg;
            });
        lists.Item1.Sort();
        lists.Item2.Sort();

        _processed = lists;

        return lists;

        return lists;

    }
}
