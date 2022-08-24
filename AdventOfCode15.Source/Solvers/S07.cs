public class S07 : BaseSolver
{
    List<(string wire, ushort value)> wires = new List<(string wire, ushort value)>();

    public S07(string[] input) : base(input)
    {
        ProcessCircuit();

        _answer1 = GetValue("a");
    }

    private void ProcessCircuit()
    {
        foreach (var instruction in _input)
        {
            var splits = instruction.Split("->");
            var valueInstruction = splits[0].Trim();
            var wire = splits[1].Trim();

            if (valueInstruction.Contains("AND"))
            {
                var valueInstructionSplits = valueInstruction.Split("AND");
                var value1 = GetValue(valueInstructionSplits[0].Trim());
                var value2 = GetValue(valueInstructionSplits[1].Trim());
                wires.Add((wire, Convert.ToUInt16(value1 & value2)));
            }
            else if (valueInstruction.Contains("OR"))
            {
                var valueInstructionSplits = valueInstruction.Split("OR");
                var value1 = GetValue(valueInstructionSplits[0].Trim());
                var value2 = GetValue(valueInstructionSplits[1].Trim());
                wires.Add((wire, Convert.ToUInt16(value1 | value2)));
            }
            else if (valueInstruction.Contains("LSHIFT"))
            {
                var valueInstructionSplits = valueInstruction.Split("LSHIFT");
                var value1 = GetValue(valueInstructionSplits[0].Trim());
                var value2 = int.Parse(valueInstructionSplits[1].Trim());
                wires.Add((wire, Convert.ToUInt16(value1 << value2)));
            }
            else if (valueInstruction.Contains("RSHIFT"))
            {
                var valueInstructionSplits = valueInstruction.Split("RSHIFT");
                var value1 = GetValue(valueInstructionSplits[0].Trim());
                var value2 = int.Parse(valueInstructionSplits[1].Trim());
                wires.Add((wire, Convert.ToUInt16(value1 >> value2)));
            }
            else if (valueInstruction.Contains("NOT"))
            {
                var valueInstructionSplits = valueInstruction.Split("NOT");
                var value1 = GetValue(valueInstructionSplits[1].Trim());
                // Needs to be recast to ushort to prevent overflow
                wires.Add((wire, (ushort)(~value1)));
            }
            else
            {
                wires.Add((wire, ushort.Parse(valueInstruction)));
            }
        }
    }

    public ushort GetValue(string wire)
    {
        return wires.First(w => w.wire == wire).value;
    }
}