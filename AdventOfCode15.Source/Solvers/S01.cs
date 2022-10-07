public class S01 : BaseSolver
{
    public S01(string input) : base(input)
    {
        var upCount = _input[0].Count(c => c == '(');
        var downCount = _input[0].Count(c => c == ')');
        _answer1 = (upCount - downCount).ToString();

        var elevation = 0;
        var position = 0;
        foreach (var character in _input[0])
        {
            position++;
            if (character == '(')
            {
                elevation++;
            }
            else
            {
                elevation--;
            }

            if (elevation == -1)
            {
                _answer2 = position.ToString();
                break;
            }
        }
    }
}