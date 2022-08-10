public class Solver01 : BaseSolver
{
    public Solver01(string input) : base(input)
    {
    }

    public override int Answer1
    {
        get
        {
            var upCount = _input[0].Count(c => c == '(');
            var downCount = _input[0].Count(c => c == ')');
            return upCount - downCount;
        }
    }

    public override int Answer2
    {
        get
        {
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
                    return position;
                }
            }

            // shouldn't happen
            return -1;
        }
    }
}