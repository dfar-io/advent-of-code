using System.Diagnostics.CodeAnalysis;

public class S07 : BaseSolver
{
    private List<WireValue> _wires = new List<WireValue>();

    public S07(string[] input)
        : base(input)
    {
        ProcessCircuit();

        // To get answer 2, change input to use the value of wire a from part 1
        // So <value of a> -> b
        Answer1 = GetWireValue("a").ToString();
    }

    private enum Operator
    {
        DIRECT,
        AND,
        OR,
        LSHIFT,
        RSHIFT,
        NOT,
    }

    [SuppressMessage(
        "StyleCop.CSharp.OrderingRules",
        "SA1201:ElementsMustAppearInTheCorrectOrder",
        Justification = "Not sure where to place a private record")]
    private record WireValue(string Wire, ushort Value);

    public bool WireValueExists(string wire)
    {
        return _wires.FirstOrDefault(w => w.Wire == wire) != null;
    }

    public ushort GetWireValue(string wire)
    {
        return _wires.First(w => w.Wire == wire).Value;
    }

    private void ProcessCircuit()
    {
        var instructions = Input.Select(s => new Instruction(s)).ToList();
        while (instructions.Count() != _wires.Count())
        {
            foreach (var instruction in instructions)
            {
                if (_wires.Any(w => w.Wire == instruction.DestinationWire))
                {
                    continue;
                }

                if (instruction.Operator == Operator.DIRECT)
                {
                    ProcessDirect(instruction);
                }
                else if (instruction.Operator == Operator.NOT)
                {
                    ProcessNot(instruction);
                }
                else if (instruction.Operator == Operator.LSHIFT)
                {
                    ProcessShift(instruction, Operator.LSHIFT);
                }
                else if (instruction.Operator == Operator.RSHIFT)
                {
                    ProcessShift(instruction, Operator.RSHIFT);
                }
                else if (instruction.Operator == Operator.AND)
                {
                    ProcessAnd(instruction);
                }
                else if (instruction.Operator == Operator.OR)
                {
                    ProcessOr(instruction);
                }
            }
        }
    }

    private void ProcessOr(Instruction instruction)
    {
        if (!WireValueExists(instruction.SourceWire1) || !WireValueExists(instruction.SourceWire2))
        {
            return;
        }

        var value1 = GetWireValue(instruction.SourceWire1);
        var value2 = GetWireValue(instruction.SourceWire2);
        _wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value1 | value2)));
    }

    private void ProcessAnd(Instruction instruction)
    {
        // See if we were provided with a value for the wire instead of a wire
        int value1 = 0, value2 = 0;

        ushort.TryParse(instruction.SourceWire1.ToString(), out ushort v1);
        if (v1 != 0)
        {
            value1 = v1;
        }
        else if (WireValueExists(instruction.SourceWire1))
        {
            value1 = GetWireValue(instruction.SourceWire1);
        }

        ushort.TryParse(instruction.SourceWire2.ToString(), out ushort v2);
        if (v2 != 0)
        {
            value2 = v2;
        }
        else if (WireValueExists(instruction.SourceWire2))
        {
            value2 = GetWireValue(instruction.SourceWire2);
        }

        if (value1 != 0 && value2 != 0)
        {
            _wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value1 & value2)));
        }
    }

    private void ProcessShift(Instruction instruction, Operator op)
    {
        if (!WireValueExists(instruction.SourceWire1))
        {
            return;
        }

        var value = GetWireValue(instruction.SourceWire1);
        var shiftValue = instruction.ShiftValue;
        if (op == Operator.LSHIFT)
        {
            _wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value << shiftValue)));
        }
        else
        {
            _wires.Add(new WireValue(instruction.DestinationWire, Convert.ToUInt16(value >> shiftValue)));
        }
    }

    private void ProcessNot(Instruction instruction)
    {
        if (!WireValueExists(instruction.SourceWire1)) { return; }
        var value = GetWireValue(instruction.SourceWire1);

        // Needs to be recast to ushort to prevent overflow
        _wires.Add(new WireValue(instruction.DestinationWire, (ushort)(~value)));
    }

    private void ProcessDirect(Instruction instruction)
    {
        if (instruction.DirectValue != -1)
        {
            _wires.Add(new WireValue(instruction.DestinationWire, (ushort)instruction.DirectValue));
        }
        else if (WireValueExists(instruction.SourceWire1))
        {
            var value = GetWireValue(instruction.SourceWire1);
            _wires.Add(new WireValue(instruction.DestinationWire, value));
        }
    }

    private class Instruction
    {
        public Instruction(string instructionString)
        {
            var splits = instructionString.Split("->");
            var valueInstruction = splits[0].Trim();
            DestinationWire = splits[1].Trim();
            DirectValue = -1;

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
                if (ushort.TryParse(valueInstruction, out var directValue))
                {
                    DirectValue = directValue;
                }
                else
                {
                    SourceWire1 = valueInstruction.Trim();
                }

                Operator = Operator.DIRECT;
            }

            if (SourceWire1 == null) { SourceWire1 = string.Empty; }
            if (SourceWire2 == null) { SourceWire2 = string.Empty; }
        }

        public string SourceWire1 { get; private set; }

        public string SourceWire2 { get; private set; }

        public int DirectValue { get; private set; }

        public Operator Operator { get; private set; }

        public int ShiftValue { get; private set; }

        public string DestinationWire { get; private set; }
    }
}
