public class S1503 : BaseSolver
{
    private HashSet<(int, int)> _visited = new HashSet<(int, int)>();
    private HashSet<(int, int)> _nonRoboVisited = new HashSet<(int, int)>();
    private HashSet<(int, int)> _roboVisited = new HashSet<(int, int)>();

    public S1503(string input)
        : this(new string[] { input })
    {
    }

    public S1503(string[] input)
        : base(input)
    {
        var x = 0;
        var y = 0;
        var nonRoboX = 0;
        var nonRoboY = 0;
        var roboX = 0;
        var roboY = 0;
        var isSantasTurn = true;

        // create initial records
        _visited.Add((x, y));
        _nonRoboVisited.Add((nonRoboX, nonRoboY));
        _roboVisited.Add((roboX, roboY));

        foreach (var direction in Input[0])
        {
            if (isSantasTurn)
            {
                ModifyLocation(ref nonRoboX, ref nonRoboY, direction);
                _nonRoboVisited.Add((nonRoboX, nonRoboY));
                isSantasTurn = false;
            }
            else
            {
                ModifyLocation(ref roboX, ref roboY, direction);
                _roboVisited.Add((roboX, roboY));
                isSantasTurn = true;
            }

            ModifyLocation(ref x, ref y, direction);
            _visited.Add((x, y));

            Answer1 = _visited.Count().ToString();
            Answer2 = _roboVisited.Union(_nonRoboVisited).Count().ToString();
        }
    }

    private static void ModifyLocation(ref int x, ref int y, char direction)
    {
        if (direction == '^')
        {
            y++;
        }
        else if (direction == 'v')
        {
            y--;
        }
        else if (direction == '<')
        {
            x--;
        }
        else if (direction == '>')
        {
            x++;
        }
    }
}