public class Solver01 : BaseSolver
{
    public Solver01()
    {
        var text = System.IO.File.ReadAllText(@"input/01.txt");

        var upCount = text.Count(c => c == '(');
        var downCount = text.Count(c => c == ')');
        Answer1 = upCount - downCount;

        var elevation = 0;
        var position = 0;
        foreach (var character in text)
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
                Answer2 = position;
                break;
            }
        }
    }
}