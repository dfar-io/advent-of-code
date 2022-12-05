public class S01 : BaseSolver
{
    public S01(string input)
        : base(input)
    {
        var upCount = Input[0].Count(c => c == '(');
        var downCount = Input[0].Count(c => c == ')');
        Answer1 = (upCount - downCount).ToString();

        var elevation = 0;
        var position = 0;
        foreach (var character in Input[0])
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
                Answer2 = position.ToString();
                break;
            }
        }
    }
}