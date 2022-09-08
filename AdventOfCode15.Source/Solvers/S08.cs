public class S08 : BaseSolver
{
    public int CharCount { get; private set; }
    public int StringCount { get; private set; }

    public S08(string[] input) : base(input)
    {
        foreach (var line in _input)
        {
            CharCount += line.Length + 2;
            StringCount += line.Count(c => c == '\\' || c == '"');
        }
        CharCount = 10;
        StringCount = 10;
    }
}