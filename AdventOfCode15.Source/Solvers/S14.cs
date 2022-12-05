public class S14 : BaseSolver
{
    // Setup allows for me to pass in optional race distance for unit tests
    public S14(string[] input)
        : this(input, 2503)
        {}

    public S14(string[] input, int raceDistance) : base(input)
    {
        var reindeerData = new List<Reindeer>();

        foreach (var inputLine in Input)
        {
            reindeerData.Add(new Reindeer(inputLine));
        }

        for (var i = 0; i < raceDistance; i++)
        {
            reindeerData.ForEach(r => r.Tick());

            var furthestDistance = reindeerData.Max(r => r.Distance);
            foreach (var reindeer in reindeerData)
            {
                if (reindeer.Distance >= furthestDistance)
                {
                    reindeer.AddPoint();
                }
            }
        }

        Answer1 = reindeerData.Max(r => r.Distance).ToString();
        Answer2 = reindeerData.Max(r => r.Points).ToString();
    }

    private class Reindeer
    {
        private int _speed;
        private int _flyDuration;
        private int _flyDurationRemaining;
        private int _restDuration;
        private int _restDurationRemaining;

        public Reindeer(string input)
        {
            var parts = input.Split(" ");
            _speed = int.Parse(parts[3]);
            _flyDuration = int.Parse(parts[6]);
            _restDuration = int.Parse(parts[13]);

            _flyDurationRemaining = _flyDuration;
            _restDurationRemaining = _restDuration;
        }

        public int Points { get; private set; }
        public int Distance { get; private set; }

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
}
