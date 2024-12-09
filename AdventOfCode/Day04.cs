namespace AdventOfCode;
/// <summary>
/// --- Day 4: Ceres Search ---
/// </summary>
public class Day04 : BaseDay
{
    private readonly string[] _input;

    public Day04()
    {
        _input = File.ReadLines(InputFilePath).ToArray();
    }

    public override ValueTask<string> Solve_1() => new($"{SearchForXmas()}");

    public override ValueTask<string> Solve_2() => new(_input.Length.ToString());

    private int searchForX_Mas()
    {
      var result = 0;

      return result;
    }

    private int SearchForXmas()
    {
      const string pattern = "XMAS";
      var result = 0;
      var maxRow = _input.Length -1;
      var maxCol = _input[0].Length -1;
      for (var r = 0; r <= maxRow; r++){
        for (var c = 0; c <= maxCol; c++)
        {
          if(_input[r][c] != 'X') continue;
          foreach(var direction in Enum.GetValues<Direction>()){
            var matches = 1;
            foreach (var m in Enumerable.Range(1,3))
            {
              var (nextRow, nextCol) = Step((r,c),direction, m);
              if (nextRow<0 || maxRow<nextRow ||
                  nextCol <0 || maxCol < nextCol ||
                  _input[nextRow][nextCol] != pattern[m])
              {
                break;
              }

              matches ++;
            }
            if (matches == 4) result++;
          }
        }
      }

      return result;
    }

    private (int,int) Step( (int ,int ) position, Direction direction, int rad = 1)=> direction switch
    {
      Direction.North => (position.Item1 - 1*rad, position.Item2),
      Direction.NorthEast => (position.Item1 - 1*rad, position.Item2+ 1*rad),
      Direction.East => (position.Item1, position.Item2 + 1*rad),
      Direction.SouthEast => (position.Item1 + 1 *rad, position.Item2 + 1*rad),
      Direction.South => (position.Item1 + 1*rad, position.Item2),
      Direction.SouthWest => (position.Item1+ 1 * rad, position.Item2-1*rad),
      Direction.West => (position.Item1, position.Item2-1*rad),
      Direction.NorthWest => (position.Item1 -1*rad, position.Item2 -1*rad),
      _ => throw new ArgumentOutOfRangeException(nameof(Direction), direction, null)

    };

    internal enum Direction{
      North,
      NorthEast,
      East,
      SouthEast,
      South,
      SouthWest,
      West,
      NorthWest,
    }

}
