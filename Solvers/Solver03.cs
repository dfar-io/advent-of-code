public class Solver03 : BaseSolver
{
    public Solver03()
    {
        var directions = System.IO.File.ReadAllText(@"input/03.txt");

        var x = 0;
        var y = 0;
        var roboX = 0;
        var roboY = 0;
        var records = new HashSet<(int, int)>();
        var roboRecords = new HashSet<(int, int)>();
        var isSantasTurn = true;

        // create initial records
        records.Add((x, y));
        roboRecords.Add((roboX, roboY));

        foreach (var direction in directions)
        {
            if (isSantasTurn)
            {
                ModifyLocation(ref x, ref y, direction);
                records.Add((x, y));
                isSantasTurn = false;
            }
            else
            {
                ModifyLocation(ref roboX, ref roboY, direction);
                roboRecords.Add((roboX, roboY));
                isSantasTurn = true;
            }
        }

        // TThis logic works for Answer 2, remove the robo-logic to get Answer 1
        Answer2 = roboRecords.Union(records).Count();
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