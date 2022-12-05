public class S18 : BaseSolver
{
    private bool[,] _currentState;

    public S18(string[] input)
        : this(input, 100)
        {}

    public S18(string[] input, int steps) : base(input)
    {
        _currentState = new bool[input.Length, input[0].Length];
        bool[,] futureState = new bool[input.Length, input[0].Length];

        // read initial state
        for (var x = 0; x < input.Length; x++)
        {
            for (var y = 0; y < input[x].Length; y++)
            {
                _currentState[x, y] = input[x][y] == '#';
            }
        }

        // iterate
        for (var i = 0; i < steps; i++)
        {
            for (var x = 0; x < input.Length; x++)
            {
                for (var y = 0; y < input[x].Length; y++)
                {
                    futureState[x, y] = GetModifiedValue(x, y);
                }
            }

            // load future state into current state
            for (var x = 0; x < input.Length; x++)
            {
                for (var y = 0; y < input[x].Length; y++)
                {
                    _currentState[x, y] = futureState[x, y];
                }
            }
        }

        // count lights
        Answer1 = _currentState.Cast<bool>().Count(x => x).ToString();
    }

    private bool GetModifiedValue(int x, int y)
    {
        // for part 2, we need to keep the corners on,
        // remove this to get answer 1
        if (IsCorner(x, y))
        {
            return true;
        }

        var neighbors = new bool[]
        {
            GetValue(x - 1, y - 1),
            GetValue(x - 1, y),
            GetValue(x - 1, y + 1),
            GetValue(x, y - 1),
            GetValue(x, y + 1),
            GetValue(x + 1, y - 1),
            GetValue(x + 1, y),
            GetValue(x + 1, y + 1)
        };

        return neighbors.Count(n => n) switch
        {
            2 => _currentState[x, y],
            3 => true,
            _ => false
        };
    }

    private bool IsCorner(int x, int y)
    {
        return (x == 0 && y == 0) ||
                    (x == 0 && y == _currentState.GetLength(1) - 1) ||
                    (x == _currentState.GetLength(0) - 1 && y == 0) ||
                    (x == _currentState.GetLength(0) - 1 && y == _currentState.GetLength(1) - 1);
    }

    private bool GetValue(int x, int y)
    {
        // out of bounds
        if (x < 0 || x >= _currentState.GetLength(0) || y < 0 || y >= _currentState.GetLength(1))
        {
            return false;
        }

        return _currentState[x, y];
    }
}