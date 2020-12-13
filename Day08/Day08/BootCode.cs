using System;
using System.Collections.Generic;

namespace Day08
{
    public class BootCode
    {
        private readonly (Instruction instruction, bool hasRun)[] _data;
        public int Accumulator { get; private set; }
        public bool HadSuccessfulTermination { get; private set; }
        public Instruction[] Instructions {
            get
            {
                return Array.ConvertAll(
                    _data,
                    new Converter<(Instruction instruction, bool hasRun), Instruction>(DataToInstructions)
                );
            }
        }

        private Instruction DataToInstructions((Instruction instruction, bool hasRun) input)
        {
            return input.instruction;
        }

        public BootCode(string[] data) : this(Array.ConvertAll(data, new Converter<string, Instruction>(StringToInstruction)))
        {
        }

        public BootCode(Instruction[] instructions)
        {
            _data = new (Instruction instruction, bool hasRun)[instructions.Length];
            for (int i = 0; i < instructions.Length; i++)
            {
                _data[i].instruction = instructions[i];
            }

            for (int i = 0; i < _data.Length; i++)
            {
                var currentData = _data[i];

                // stop processing if already reaches.. in infinite loop
                if (currentData.hasRun) { return; }

                _data[i].hasRun = true;
                switch (currentData.instruction.Operation)
                {
                    case Consts.Accumulate:
                        Accumulator += currentData.instruction.Value;
                        break;
                    case Consts.Jump:
                        i += currentData.instruction.Value - 1;
                        break;
                    default:
                        break;
                }
            }

            HadSuccessfulTermination = true;
        }

        private static Instruction StringToInstruction(string record)
        {
            return new Instruction(record);
        }
    }
}
