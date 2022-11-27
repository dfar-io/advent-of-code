public class S14 : BaseSolver
{
    // Setup allows for me to pass in optional race distance for unit tests
    public S14(string[] input) : this(input, 2503) {}

    public S14(string[] input, int raceDistance) : base(input)
    {
        var reindeerData = new List<Reindeer>();
        var furthestDistance = 0;

        foreach (var inputLine in _input)
        {
            reindeerData.Add(new Reindeer(inputLine));
        }

        foreach (var reindeer in reindeerData)
        {
            for (var i = 0; i < raceDistance; i++)
            {
                reindeer.Tick();
            }

            if (reindeer.Distance > furthestDistance) { furthestDistance = reindeer.Distance; }
        }

        _answer1 = furthestDistance.ToString();
    }
}

class Reindeer
{
    private int _speed;
    private int _flyDuration;
    private int _flyDurationRemaining;
    private int _restDuration;
    private int _restDurationRemaining;
    
    public int Points { get; private set; }
    public int Distance { get; private set; }

    public Reindeer(string input)
    {
        var parts = input.Split(" ");
        _speed = int.Parse(parts[3]);
        _flyDuration = int.Parse(parts[6]);
        _restDuration = int.Parse(parts[13]);

        _flyDurationRemaining = _flyDuration;
        _restDurationRemaining = _restDuration;
    }

    public void Tick()
    {
        if (_flyDurationRemaining > 0)
        {
            _flyDurationRemaining--;
            Distance += _speed;
            return;
        }
                
        if (_restDurationRemaining > 0)
        {
            _restDurationRemaining--;
            return;
        }

        _flyDurationRemaining = _flyDuration - 1;
        _restDurationRemaining = _restDuration;
        Distance += _speed;
    }

    public void AddPoint()
    {
        Points++;
    }
}