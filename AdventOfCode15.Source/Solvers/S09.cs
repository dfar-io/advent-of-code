public class S09 : BaseSolver
{
    public S09(string[] input) : base(input)
    {
        var a1 = 0;
        var a2 = 0;

        // 1. Create list of distances
        var distances = new List<(string D1, string D2, int Distance)>();
        foreach (var distanceString in _input)
        {
            var parts = distanceString.Split();
            var d1 = parts[0];
            var d2 = parts[2];
            var distance = Int32.Parse(parts[4]);
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
        var permutations = GetPermutations(locations, locations.Count());
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

        _answer1 = a1.ToString();
        _answer2 = a2.ToString();
    }

    // https://stackoverflow.com/a/10630026
    private static IEnumerable<IEnumerable<string>> GetPermutations(
        IEnumerable<string> list, int length)
    {
        if (length == 1) return list.Select(t => new string[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (s1, s2) => s1.Concat(new string[] { s2 }));
    }
}