public class S1525 : BaseSolver
{
    public S1525(string input)
        : base(input)
    {
        long result = 20151125;

        var endRow = int.Parse(Input[0].Split(',')[0]);
        var endColumn = int.Parse(Input[0].Split(',')[1]);

        for (var row = 1; row <= endRow + endColumn - 1; row++)
        {
            for (var column = 1; column <= row; column++)
            {
                if (row - column + 1 == endRow && column == endColumn)
                {
                    break;
                }

                result = (result * 252533) % 33554393;
            }
        }

        Answer1 = result.ToString();
    }
}