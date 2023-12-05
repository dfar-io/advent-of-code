using System.Text;

public class S1510 : BaseSolver
{
    public S1510(string input)
        : base(input)
    {
        var result = Input[0];

        for (var i = 0; i < 50; i++)
        {
            result = PerformLookAndSay(result);
        }

        // To get answer 1, change the rep count to 40
        Answer2 = result.Length.ToString();
    }

    private string PerformLookAndSay(string input)
    {
        var result = new StringBuilder();
        for (var i = 0; i < input.Length; i++)
        {
            var current = input[i];
            var count = 1;
            while (i + 1 < input.Length && input[i + 1] == current)
            {
                count++;
                i++;
            }

            result.Append(count);
            result.Append(current);
        }

        return result.ToString();
    }
}