public class S1520 : BaseSolver
{
    public S1520(string input)
        : base(input)
    {
        for (int i = 1; i < int.MaxValue; i++)
        {
            // for answer 1, use 10
            // int presents = GetFactors(i).Sum() * 10;
            int presents = GetFactors(i).Where(f => f * 50 >= i).Sum() * 11;
            if (presents >= int.Parse(Input[0]))
            {
                Answer1 = i.ToString();
                break;
            }
        }
    }

    // https://stackoverflow.com/a/3433222
    private static IEnumerable<int> GetFactors(int x)
    {
        for (int i = 1; i * i <= x; i++)
        {
            if (x % i == 0)
            {
                yield return i;
                if (i != x / i)
                {
                    yield return x / i;
                }
            }
        }
    }
}