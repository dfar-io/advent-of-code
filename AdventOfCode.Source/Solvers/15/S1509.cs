public class S1509 : BaseSolver
{
    public S1509(string[] input)
        : base(input)
    {
        var a1 = 0;
        var a2 = 0;

        // 1. Create list of distances
        var distances = new List<(string D1, string D2, int Distance)>();
        foreach (var distanceString in Input)
        {
            var parts = distanceString.Split();
            var d1 = parts[0];
            var d2 = parts[2];
            var distance = int.Parse(parts[4]);
            distances.Add((d1, d2, distance));
        }

        // 2. Get all locations
        var locations = new HashSet<string>();
        foreach (var distance in distances)
        {
            locations.Add(distance.D1);
            locations.Add(distance.D2);
        }

        // 3. Get permutations, find shortest distance
        var permutations = PermutationGenerator.Generate(locations, locations.Count());
        foreach (var permutation in permutations)
        {
            var overallDistance = 0;
            for (var i = 0; i < permutation.Count() - 1; i++)
            {
                var first = permutation.ElementAt(i);
                var second = permutation.ElementAt(i + 1);

                var distance = distances.First(d => (d.D1 == first && d.D2 == second) || (d.D2 == first && d.D1 == second));
                overallDistance += distance.Distance;
            }

            if (a1 == 0 || overallDistance < a1)
            {
                a1 = overallDistance;
            }

            if (a2 == 0 || overallDistance > a2)
            {
                a2 = overallDistance;
            }
        }

        Answer1 = a1.ToString();
        Answer2 = a2.ToString();
    }
}