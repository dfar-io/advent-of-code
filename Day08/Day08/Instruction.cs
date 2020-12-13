using System;

namespace Day08
{
    public class Instruction
    {
        public string Operation { get; set; }
        public int Value { get; private set; }

        public Instruction(string data)
        {
            var values = data.Split(" ");

            Operation = values[0];
            Value = int.Parse(values[1]);
        }
    }
}
