public class S06 : BaseSolver
{
    private int _answer1;
    private int _answer2;

    public S06(string[] input) : base(input)
    {
        var lights = new bool[1000,1000];

        foreach (var command in _input)
        {
            var splits = command.Split(" ");

            if (splits.Count() == 4)
            {
                ToggleLights(lights, splits);
            }
            else
            {
                TurnLights(lights, splits);
            }
        }

        // Count the lights that are on
        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < 1000; j++)
            {
                if (lights[i, j])
                {
                    _answer1++;
                }
            }
        }
    }

    private static void ToggleLights(bool[,] lights, string[] splits)
    {
        var start = splits[1].Split(",");
        var end = splits[3].Split(",");
        var x1 = int.Parse(start[0]);
        var y1 = int.Parse(start[1]);
        var x2 = int.Parse(end[0]);
        var y2 = int.Parse(end[1]);
        for (var x = x1; x <= x2; x++)
        {
            for (var y = y1; y <= y2; y++)
            {
                lights[x, y] = !lights[x, y];
            }
        }
    }

    private static void TurnLights(bool[,] lights, string[] splits)
    {
        var isOn = splits[1] == "on";
        var start = splits[2].Split(",");
        var end = splits[4].Split(",");
        var x1 = int.Parse(start[0]);
        var y1 = int.Parse(start[1]);
        var x2 = int.Parse(end[0]);
        var y2 = int.Parse(end[1]);
        for (var x = x1; x <= x2; x++)
        {
            for (var y = y1; y <= y2; y++)
            {
                lights[x, y] = isOn;
            }
        }
    }

    public override int Answer1 => _answer1;

    public override int Answer2 => _answer2;
}