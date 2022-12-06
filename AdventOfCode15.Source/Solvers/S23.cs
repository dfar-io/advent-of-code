public class S23 : BaseSolver
{
    public S23(string[] input)
        : base(input)
    {
        int[] registers = { 1, 0 };

        for (int i = 0; i < Input.Length; i++)
        {
            var instructionLine = Input[i];
            var parts = instructionLine.Split(" ");
            var instruction = parts[0];
            var registerOrOffset = parts[1].TrimEnd(',');
            var offset = parts.Length == 3 ? int.Parse(parts[2]) : 0;

            var register = registerOrOffset == "a" ?
                0 :
                registerOrOffset == "b" ?
                    1 :
                    int.Parse(registerOrOffset);
            switch (instruction)
            {
                case "hlf":
                    registers[register] /= 2;
                    break;
                case "tpl":
                    registers[register] *= 3;
                    break;
                case "inc":
                    registers[register]++;
                    break;
                case "jmp":
                    i += register - 1;
                    break;
                case "jie":
                    if (registers[register] % 2 == 0)
                    {
                        i += offset - 1;
                    }

                    break;
                case "jio":
                    if (registers[register] == 1)
                    {
                        i += offset - 1;
                    }

                    break;
            }
        }

        Answer1 = registers[1].ToString();
    }
}