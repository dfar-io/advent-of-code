using System.Collections;

public class S1601 : BaseSolver
{
    public S1601(string input)
        : base(input)
    {
        var instructions = Input[0].Split(',');
        var x = 0;
        var y = 0;

        // 0 - south, 1 - east, 2 - north, 3 - west
        var facingDirection = 0;

        foreach (var instruction in instructions)
        {
            var trimmedInstruction = instruction.Trim();
            facingDirection = trimmedInstruction[0] == 'R' ?
                (facingDirection == 3 ? 0 : facingDirection + 1) :
                (facingDirection == 0 ? 3 : facingDirection - 1);

            var distance = int.Parse(trimmedInstruction[1].ToString());

            switch (facingDirection)
            {
                case 0:
                    y += distance;
                    break;
                case 1:
                    x += distance;
                    break;
                case 2:
                    y -= distance;
                    break;
                case 3:
                    x -= distance;
                    break;
                default:
                    throw new Exception("facingDirection is invalid.");
            }
        }

        Answer1 = Math.Abs(x + y).ToString();
    }
}