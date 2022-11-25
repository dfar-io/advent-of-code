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

        _answer1 = "0";
    }
}