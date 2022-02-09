using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondKata;

public class Diamond
{
    public static char StartingLetter = 'A';//65

    public List<string> GetDiamond(char c)
    {
        if (!char.IsLetter(c) || !char.IsUpper(c))
            throw new ArgumentException($"Invalid Character provider: {c}");

        IEnumerable<string> diamondRows = CreateHalfDiamond(c).ToList();
        var mirroredRows = MirrorDiamond(diamondRows);
        var diamond = diamondRows.Concat(mirroredRows);
        return diamond.ToList();

    }

    private static IEnumerable<string> CreateHalfDiamond(char lastLetter)
    {
        List<string> rows = new();
        for (var i = 0; i <= lastLetter - StartingLetter; i++)
        {
            rows.Add(CreateRow(lastLetter, i));
        }

        return rows;
    }

    private static IEnumerable<string> MirrorDiamond(IEnumerable<string> diamondRows)
    {
        return diamondRows.SkipLast(1).Reverse();
    }

    private static string CreateRow(char lastLetter, int index)
    {
        char currentLetter = (char)(StartingLetter + index);
        var outerDashes = GetDashes(lastLetter - currentLetter);

        var row = $"{outerDashes}{currentLetter}" +
                        $"{InsideDashes(currentLetter)}" +
                        $"{(index > 0 ? currentLetter.ToString() : string.Empty)}" +
                        $"{outerDashes}";

        return row;
    }
    private static string GetDashes(int count)
    {
        return new string('-', count);
    }
    private static string InsideDashes(int currentLetter)
    {
        int index = currentLetter - StartingLetter;
        return index == 0 ? GetDashes(0) : GetDashes((index * 2) - 1);
    }


}