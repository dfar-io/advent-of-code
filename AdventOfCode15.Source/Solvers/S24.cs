using System.Numerics;

public class S24 : BaseSolver
{
    public S24(string[] input)
        : base(input)
    {
        var fourthOfWeight = Input.Select(int.Parse).Sum() / 4;
        var packages = Input.Select(int.Parse).ToArray();

        var minPackages = int.MaxValue;
        var lowestQuantumEntanglement = new BigInteger(long.MaxValue);

        var combinations = GetCombinations(packages, fourthOfWeight);
        foreach (var combinationString in combinations)
        {
            var combination = combinationString.Split(',').Select(int.Parse).ToArray();
            if (combination.Length <= minPackages)
            {
                minPackages = combination.Length;
                var quantumEntanglement = combination.Aggregate((BigInteger)1, (a, b) => a * b);
                if (quantumEntanglement < lowestQuantumEntanglement)
                {
                    lowestQuantumEntanglement = quantumEntanglement;
                }
            }
        }

        Answer1 = lowestQuantumEntanglement.ToString();
    }

    // https://stackoverflow.com/a/10739219
    public static IEnumerable<string> GetCombinations(int[] set, int sum, string values = "")
    {
        for (int i = 0; i < set.Length; i++)
        {
            int left = sum - set[i];
            string vals = set[i] + "," + values;
            if (left == 0)
            {
                yield return vals.TrimEnd(',');
            }
            else
            {
                int[] possible = set.Take(i).Where(n => n <= sum).ToArray();
                if (possible.Length > 0) {
                    foreach (string s in GetCombinations(possible, left, vals))
                    {
                        yield return s;
                    }
                }
            }
        }
    }
}