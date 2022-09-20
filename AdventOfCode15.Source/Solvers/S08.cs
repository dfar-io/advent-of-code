using System.Text;

public class S08 : BaseSolver
{
    public int CharCount { get; private set; }
    public int StringCount { get; private set; }

    public S08(string[] input) : base(input)
    {
        foreach (var line in _input)
        {
            CharCount += GetCharCount(line);
            StringCount += line.Length;
        }
    }

    private int GetCharCount(string value)
    {
        var result = 0;
        foreach (var character in value)
        {
            if (character == '\'')
            {
                result += 4;
            }
            else if (character == '\"')
            {
                result += 2;
            }
            else
            {
                result++;
            }
        }

        // Include quotes
        return result + 2;
    }
}