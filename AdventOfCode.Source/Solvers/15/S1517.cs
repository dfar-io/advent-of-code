public class S1517 : BaseSolver
{
    public S1517(string[] input, int eggNogAmount = 150)
        : base(input)
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
                    total += int.Parse(Input[j]);
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

        Answer1 = availableCombinations.ToString();
        Answer2 = availableCombinationsWithMinContainers.ToString();
    }
}