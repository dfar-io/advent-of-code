public class S17 : BaseSolver
{
    public S17(string[] input) : this(input, 150) {}

    public S17(string[] input, int eggNogAmount) : base(input)
    {
        var bitCount = Math.Pow(2, input.Length);
        var availableCombinations = 0;
        var availableCombinationsWithMinContainers = 0;
        var leastContainersUsed = int.MaxValue;

        for (int i = 0; i < bitCount; i++)
        {
            var bitString = Convert.ToString(i, 2).PadLeft(input.Length, '0');
            var bitArray = bitString.Select(c => c == '1').ToArray();

            var total = 0;
            for (int j = 0; j < bitArray.Length; j++)
            {
                if (bitArray[j])
                {
                    total += int.Parse(_input[j]);
                }
            }

            if (total == eggNogAmount)
            {
                availableCombinations++;
                if (bitArray.Count(b => b) < leastContainersUsed)
                {
                    leastContainersUsed = bitArray.Count(b => b);
                    availableCombinationsWithMinContainers = 1;
                }
                else if (bitArray.Count(b => b) == leastContainersUsed)
                {
                    availableCombinationsWithMinContainers++;
                }
            }
        }

        _answer1 = availableCombinations.ToString();
        _answer2 = availableCombinationsWithMinContainers.ToString();
    }
}