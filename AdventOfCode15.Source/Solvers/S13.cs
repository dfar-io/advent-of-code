public class S13 : BaseSolver
{
    public S13(string[] input) : base(input)
    {
        var attendees = new HashSet<string>();
        var data = new List<(string Name1, int Change, string Name2)>();

        foreach (var inputLine in _input)
        {
            var parts = inputLine.Split(" ");
            var name1 = parts[0];
            
            var change = int.Parse(parts[3]);
            if (parts[2] == "lose") { change *= -1; }

            var name2 = parts[10].TrimEnd('.');

            data.Add((name1, change, name2));

            attendees.Add(name1);
            attendees.Add(name2);
        }

        // adding myself for part 2, remove this to get answer 1
        const string Myself = "Myself";
        attendees.Add(Myself);
        foreach (var attendee in attendees)
        {
            data.Add((Myself, 0, attendee));
            data.Add((attendee, 0, Myself));
        }

        var optimalRating = 0;
        var permutations =
            PermutationGenerator.Generate(attendees, attendees.Count());
        foreach (var permutation in permutations)
        {
            var sum = 0;
            for (var i = 0; i < permutation.Count(); i++)
            {
                var basePerson = permutation.ElementAt(i);
                var seat1 = permutation.ElementAt(i == permutation.Count() - 1 ? 0 : i + 1);
                var seat2 = permutation.ElementAt(i == 0 ? permutation.Count() - 1 : i - 1);

                var difference1 = data.First(d => (d.Name1 == basePerson && d.Name2 == seat1)).Change;
                var difference2 = data.First(d => (d.Name1 == basePerson && d.Name2 == seat2)).Change;

                sum += difference1 + difference2;
            }

            if (sum > optimalRating) { optimalRating = sum; }
        }

        _answer1 = optimalRating.ToString();
    }
}