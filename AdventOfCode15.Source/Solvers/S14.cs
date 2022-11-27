public class S14 : BaseSolver
{
    // Setup allows for me to pass in optional race distance for unit tests
    public S14(string[] input) : this(input, 2503) {}

    public S14(string[] input, int raceDistance) : base(input)
    {
        var reindeerData = new List<(int Speed, int FlyDuration, int RestDuration)>();
        var furthestDistance = 0;

        foreach (var inputLine in _input)
        {
            var parts = inputLine.Split(" ");
            var speed = int.Parse(parts[3]);
            var flyDuration = int.Parse(parts[6]);
            var restDuration = int.Parse(parts[13]);

            reindeerData.Add((speed, flyDuration, restDuration));
        }

        foreach (var reindeer in reindeerData)
        {
            var flyDurationRemaining = reindeer.FlyDuration;
            var restDurationRemaining = reindeer.RestDuration;
            var distance = 0;
            
            for (var i = 0; i < raceDistance; i++)
            {
                if (flyDurationRemaining > 0)
                {
                    flyDurationRemaining--;
                    distance += reindeer.Speed;
                    continue;
                }
                
                if (restDurationRemaining > 0)
                {
                    restDurationRemaining--;
                    continue;
                }

                flyDurationRemaining = reindeer.FlyDuration - 1;
                restDurationRemaining = reindeer.RestDuration;
                distance += reindeer.Speed;
            }

            if (distance > furthestDistance) { furthestDistance = distance; }
        }

        // between 2640 and 2800
        _answer1 = furthestDistance.ToString();
    }
}