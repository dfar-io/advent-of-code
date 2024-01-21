internal enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3,
}

public class S1601 : BaseSolver
{
    public S1601(string input)
        : base(input)
    {
        var instructions = Input[0].Split(',');
        var x = 0;
        var y = 0;
        var facingDirection = Direction.North;

        foreach (var instruction in instructions)
        {
            var trimmedInstruction = instruction.Trim();
            facingDirection = trimmedInstruction[0] == 'R' ?
                (facingDirection == Direction.West ? Direction.North : facingDirection + 1) :
                (facingDirection == Direction.North ? Direction.West : facingDirection - 1);

            var distance = int.Parse(trimmedInstruction[1..]);

            switch (facingDirection)
            {
                case Direction.North:
                    y += distance;
                    break;
                case Direction.East:
                    x += distance;
                    break;
                case Direction.South:
                    y -= distance;
                    break;
                case Direction.West:
                    x -= distance;
                    break;
                default:
                    throw new Exception("facingDirection is invalid.");
            }

            // TODO: Keep a list of visited coordinates and see if we visit one
            // twice. If so, mark as answer 2.
        }

        Answer1 = (Math.Abs(x) + Math.Abs(y)).ToString();
    }
}
