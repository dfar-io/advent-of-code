public class S15 : BaseSolver
{
    public S15(string[] input)
        : base(input)
    {
        var data = new List<(int Capacity, int Durability, int Flavor, int Texture, int Calories)>();
        foreach (var inputLine in Input)
        {
            var parts = inputLine.Split(" ");
            var capacity = int.Parse(parts[2].TrimEnd(','));
            var durability = int.Parse(parts[4].TrimEnd(','));
            var flavor = int.Parse(parts[6].TrimEnd(','));
            var texture = int.Parse(parts[8].TrimEnd(','));
            var calories = int.Parse(parts[10]);
            data.Add((capacity, durability, flavor, texture, calories));
        }

        var optimalScore = 0;
        var optimalScore500Calories = 0;
        var combinations = GetValidCombinations();
        foreach (var combination in combinations)
        {
            var capacity = 0;
            var durability = 0;
            var flavor = 0;
            var texture = 0;
            var calories = 0;
            for (var i = 0; i < combination.Length; i++)
            {
                capacity += combination[i] * data[i].Capacity;
                durability += combination[i] * data[i].Durability;
                flavor += combination[i] * data[i].Flavor;
                texture += combination[i] * data[i].Texture;
                calories += combination[i] * data[i].Calories;
            }

            if (capacity < 0 || durability < 0 || flavor < 0 || texture < 0)
            {
                continue;
            }

            var score = capacity * durability * flavor * texture;
            if (score > optimalScore)
            {
                optimalScore = score;
            }

            if (calories == 500 && score > optimalScore500Calories)
            {
                optimalScore500Calories = score;
            }
        }

        Answer1 = optimalScore.ToString();
        Answer2 = optimalScore500Calories.ToString();
    }

    // This is set hardcoded to 4 ingredients (aka the puzzle input)
    // If I could figure out a way to make this dynamic I would
    private List<int[]> GetValidCombinations()
    {
        var combinations = new List<int[]>();
        for (var i = 0; i <= 100; i++)
        {
            for (var j = 0; j <= 100 - i; j++)
            {
                for (var k = 0; k <= 100 - i - j; k++)
                {
                    var l = 100 - i - j - k;
                    combinations.Add(new int[] { i, j, k, l });
                }
            }
        }

        return combinations;
    }
}
