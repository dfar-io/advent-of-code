public class S1506 : BaseSolver
{
    public S1506(string[] input)
        : base(input)
    {
        var lights = new bool[1000, 1000];
        var lightsP2 = new int[1000, 1000];
        var a1 = 0;
        var a2 = 0;

        foreach (var commandString in Input)
        {
            var command = new Command(commandString);

            if (command.CommandType == CommandType.Toggle)
            {
                ToggleLights(lights, command);
                ToggleLightsP2(lightsP2, command);
            }
            else
            {
                TurnLights(lights, command);
                TurnLightsP2(lightsP2, command);
            }
        }

        // Count the lights that are on
        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < 1000; j++)
            {
                if (lights[i, j])
                {
                    a1++;
                }

                a2 += lightsP2[i, j];
            }
        }

        Answer1 = a1.ToString();
        Answer2 = a2.ToString();
    }

    private enum CommandType
    {
        On,
        Off,
        Toggle,
    }

    private static void ToggleLights(bool[,] lights, Command command)
    {
        for (var x = command.X1; x <= command.X2; x++)
        {
            for (var y = command.Y1; y <= command.Y2; y++)
            {
                lights[x, y] = !lights[x, y];
            }
        }
    }

    private static void ToggleLightsP2(int[,] lights, Command command)
    {
        for (var x = command.X1; x <= command.X2; x++)
        {
            for (var y = command.Y1; y <= command.Y2; y++)
            {
                lights[x, y] = lights[x, y] + 2;
            }
        }
    }

    private static void TurnLights(bool[,] lights, Command command)
    {
        for (var x = command.X1; x <= command.X2; x++)
        {
            for (var y = command.Y1; y <= command.Y2; y++)
            {
                lights[x, y] = command.IsTurnOn;
            }
        }
    }

    private static void TurnLightsP2(int[,] lights, Command command)
    {
        for (var x = command.X1; x <= command.X2; x++)
        {
            for (var y = command.Y1; y <= command.Y2; y++)
            {
                lights[x, y] = command.IsTurnOn ? lights[x, y] + 1 : Math.Max(lights[x, y] - 1, 0);
            }
        }
    }

    private class Command
    {
        public Command(string input)
        {
            var splits = input.Split(" ");
            var start = new string[0];
            var end = new string[0];

            if (splits.Count() == 4)
            {
                CommandType = CommandType.Toggle;
                start = splits[1].Split(",");
                end = splits[3].Split(",");
            }
            else
            {
                CommandType = splits[1] == "on" ? CommandType.On : CommandType.Off;
                start = splits[2].Split(",");
                end = splits[4].Split(",");
            }

            X1 = int.Parse(start[0]);
            Y1 = int.Parse(start[1]);
            X2 = int.Parse(end[0]);
            Y2 = int.Parse(end[1]);
        }

        public CommandType CommandType { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public bool IsTurnOn => CommandType == CommandType.On;
    }
}
