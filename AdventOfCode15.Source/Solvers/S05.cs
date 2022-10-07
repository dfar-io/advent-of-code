using System.Text.RegularExpressions;

public class S05 : BaseSolver
{
    public S05(string[] input) : base(input)
    {
        var a1Count = 0;
        var a2Count = 0;
        foreach (var value in _input)
        {
            if (IsNiceString(value))
            {
                a1Count++;
            }

            if (IsNiceStringP2(value))
            {
                a2Count++;
            }
        }
        _answer1 = a1Count.ToString();
        _answer2 = a2Count.ToString();
    }

    private bool IsNiceString(string value)
    {
        var hasThreeVowels = value.Count(c => "aeiou".Contains(c)) >= 3;
        // Grabs pairs of letters next to each other
        Regex regex = new Regex("(.)\\1{1,1}");
        var hasDoubleLetter = regex.Matches(value).Count() >= 1;
        var hasInvalidStrings = new[] { "ab", "cd", "pq", "xy" }.Any(c => value.Contains(c));
        return hasThreeVowels && hasDoubleLetter && !hasInvalidStrings;
    }

    private bool IsNiceStringP2(string value)
    {
        var containsPair = false;
        var containsRepeatWithLetterBetween = false;

        for (int i = 0; i < value.Length - 1; i++)
        {
            if (!containsPair)
            {
                var pair = value.Substring(i, 2);
                var pairIndex = value.IndexOf(pair, i + 2);
                if (pairIndex > -1)
                {
                    containsPair = true;
                }
            }

            if (i < value.Length - 2 && value[i] == value[i + 2])
            {
                containsRepeatWithLetterBetween = true;
            }
        }

        return containsPair && containsRepeatWithLetterBetween;
    }
}