using FluentAssertions;
using NUnit.Framework;

namespace Day08.Tests
{
    public class BootCodeFixerTests
    {
        [Test]
        public void Runs_Fixed_Program_Correctly()
        {
            var bootCode = new BootCode(new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            });
            var bootCodeFixer = new BootCodeFixer(bootCode);

            bootCodeFixer.Accumulator.Should().Be(8);
        }
    }
}