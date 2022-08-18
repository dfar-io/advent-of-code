using System.Text.RegularExpressions;

public class S05 : BaseSolver
{
    private int _answer1;
    private int _answer2;

    public S05(string[] input) : base(input)
    {
        foreach (var value in _input)
        {
            if (IsNiceString(value))
            {
                _answer1++;
            }
        }
    }

    public override int Answer1 => _answer1;

    public override int Answer2 => _answer2;

    private bool IsNiceString(string value)
    {
        var hasThreeVowels = value.Count(c => "aeiou".Contains(c)) >= 3;
        // Grabs pairs of letters next to each other
        Regex regex = new Regex("(.)\\1{1,1}");
        var hasDoubleLetter = regex.Matches(value).Count() >= 1;
        var hasInvalidStrings = new[] { "ab", "cd", "pq", "xy" }.Any(c => value.Contains(c));
        return hasThreeVowels && hasDoubleLetter && !hasInvalidStrings;
    }
}