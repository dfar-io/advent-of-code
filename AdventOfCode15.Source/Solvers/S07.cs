public class S07 : BaseSolver
{
    List<WireValue> wires = new List<WireValue>();

    public S07(string[] input) : base(input)
    {
        ProcessCircuit();

        _answer1 = GetWireValue("a").Value;
    }

    private void ProcessCircuit()
    {
        var instructions = _input.Select(s => new Instruction(s)).ToList();
        while (instructions.Count() != wires.Count())
        {
            foreach (var instruction in instructions)
            {
                if (wires.Any(w => w.Wire == instruction.DestinationWire))
                {
                    continue;
                }

                if (instruction.Operator == Operator.DIRECT)
                {
                    wires.Add(new WireValue(instruction.DestinationWire, instruction.DirectValue));
                }
                else if (instruction.Operator == Operator.NOT && WireValueExists(instruction.SourceWire1))
                {
                    var value = GetWireValue(instruction.SourceWire1).Value;
                    // Needs to be recast to ushort to prevent overflow
                    wires.Add(new WireValue(instruction.DestinationWire, (ushort)(~value)));
                }
                else if (instruction.Operator == Operator.LSHIFT && WireValueExists(instruction.SourceWire1))
                {
                    var value = GetWireValue(instruction.SourceWire1).Value;
                    var shiftValue = instruction.ShiftValue;
                    wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value << shiftValue)));
                }
                else if (instruction.Operator == Operator.RSHIFT && WireValueExists(instruction.SourceWire1))
                {
                    var value = GetWireValue(instruction.SourceWire1).Value;
                    var shiftValue = instruction.ShiftValue;
                    wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value >> shiftValue)));
                }
                else if (instruction.Operator == Operator.AND && WireValueExists(instruction.SourceWire1) && WireValueExists(instruction.SourceWire2))
                {
                    var value1 = GetWireValue(instruction.SourceWire1).Value;
                    var value2 = GetWireValue(instruction.SourceWire2).Value;
                    wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value1 & value2)));
                }
                else if (instruction.Operator == Operator.OR && WireValueExists(instruction.SourceWire1) && WireValueExists(instruction.SourceWire2))
                {
                    var value1 = GetWireValue(instruction.SourceWire1).Value;
                    var value2 = GetWireValue(instruction.SourceWire2).Value;
                    wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value1 | value2)));
                }
            }
        }

        _answer1 = GetWireValue("a").Value;
    }

    public bool WireValueExists(string wire)
    {
        return wires.FirstOrDefault(w => w.Wire == wire) != null;
    }

    public WireValue GetWireValue(string wire)
    {
        return wires.First(w => w.Wire == wire);
    }
}

public record WireValue(string Wire, ushort Value);

class Instruction
{
    public string SourceWire1 { get; private set; }
    public string SourceWire2 { get; private set; }
    public ushort DirectValue { get; private set; }
    public Operator Operator { get; private set; }
    public int ShiftValue { get; private set; }
    public string DestinationWire { get; private set; }

    public Instruction(string instructionString)
    {
        var splits = instructionString.Split("->");
        var valueInstruction = splits[0].Trim();
        DestinationWire = splits[1].Trim();

        if (valueInstruction.Contains("AND"))
        {
            var valueInstructionSplits = valueInstruction.Split("AND");
            SourceWire1 = valueInstructionSplits[0].Trim();
            SourceWire2 = valueInstructionSplits[1].Trim();
            Operator = Operator.AND;
        }
        else if (valueInstruction.Contains("OR"))
        {
            var valueInstructionSplits = valueInstruction.Split("OR");
            SourceWire1 = valueInstructionSplits[0].Trim();
            SourceWire2 = valueInstructionSplits[1].Trim();
            Operator = Operator.OR;
        }
        else if (valueInstruction.Contains("LSHIFT"))
        {
            var valueInstructionSplits = valueInstruction.Split("LSHIFT");
            SourceWire1 = valueInstructionSplits[0].Trim();
            ShiftValue = int.Parse(valueInstructionSplits[1].Trim());
            Operator = Operator.LSHIFT;
        }
        else if (valueInstruction.Contains("RSHIFT"))
        {
            var valueInstructionSplits = valueInstruction.Split("RSHIFT");
            SourceWire1 = valueInstructionSplits[0].Trim();
            ShiftValue = int.Parse(valueInstructionSplits[1].Trim());
            Operator = Operator.RSHIFT;
        }
        else if (valueInstruction.Contains("NOT"))
        {
            var valueInstructionSplits = valueInstruction.Split(" ");
            SourceWire1 = valueInstructionSplits[1].Trim();
            Operator = Operator.NOT;
        }
        else
        {
            DirectValue = Convert.ToUInt16(valueInstruction);
            Operator = Operator.DIRECT;
        }

        if (SourceWire1 == null) { SourceWire1 = string.Empty; }
        if (SourceWire2 == null) { SourceWire2 = string.Empty; }
    }
}

enum Operator
{
    DIRECT,
    AND,
    OR,
    LSHIFT,
    RSHIFT,
    NOT
}