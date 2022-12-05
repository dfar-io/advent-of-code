public class S08 : BaseSolver
{
    public int CharCount { get; private set; }
    public int Char2Count { get; private set; }
    public int StringCount { get; private set; }

    public S08(string[] input)
        : base(input)
    {
        foreach (var line in _input)
        {
            CharCount += GetCharCount(line);
            Char2Count += GetChar2Count(line);
            StringCount += GetStringCount(line);
        }

        Answer1 = (CharCount - StringCount).ToString();
        Answer2 = (Char2Count - CharCount).ToString();
    }

    private int GetStringCount(string value)
    {
        // trim off the quotes
        var trimmed = value[1..^1];
        var result = 0;
        for (int i = 0; i < trimmed.Length; i++)
        {
            if (trimmed[i] == '\\')
            {
                if (trimmed[i + 1] == '"' || trimmed[i + 1] == '\\')
                {
                    i++;
                }
                else if (trimmed[i + 1] == 'x')
                {
                    i += 3;
                }
            }

            result++;
        }

        return result;
    }

    private int GetCharCount(string value)
    {
        var result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '\\' && value[i + 1] == 'x')
            {
                i += 3;
                result += 3;
            }

            result++;
        }

        return result;
    }

    private int GetChar2Count(string value)
    {
        var result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '"' || value[i] == '\\')
            {
                result += 2;
            }
            else
            {
                result++;
            }
        }

        // Add the quotes
        return result + 2;
    }
}