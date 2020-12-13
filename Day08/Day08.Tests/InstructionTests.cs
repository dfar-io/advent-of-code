using FluentAssertions;
using NUnit.Framework;

namespace Day08.Tests
{
    public class InstructionTests
    {
        [Test]
        [TestCase("nop +0", Consts.NoOperation, 0)]
        [TestCase("acc +1", Consts.Accumulate, 1)]
        [TestCase("jmp +4", Consts.Jump, 4)]
        [TestCase("acc +3", Consts.Accumulate, 3)]
        [TestCase("jmp -3", Consts.Jump, -3)]
        [TestCase("acc -99", Consts.Accumulate, -99)]
        [TestCase("acc +1", Consts.Accumulate, 1)]
        [TestCase("jmp -4", Consts.Jump, -4)]
        [TestCase("acc +6", Consts.Accumulate, 6)]
        public void Constructs_Correctly(string data, string operation, int value)
        {
            var instruction = new Instruction(data);

            instruction.Operation.Should().Be(operation);
            instruction.Value.Should().Be(value);
        }
    }
}