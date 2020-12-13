using FluentAssertions;
using NUnit.Framework;

namespace Day08.Tests
{
    public class BootCodeTests
    {
        private string[] _data;
        private string[] _dataSuccessfulTermination;

        [SetUp]
        public void Setup()
        {
            _data = new string[]
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
            };
            _dataSuccessfulTermination = new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "nop -4",
                "acc +6"
            };
        }

        [Test]
        public void Processes_Accumulator_Correctly()
        {
            var bootCode = new BootCode(_data);

            bootCode.Accumulator.Should().Be(5);
        }

        [Test]
        public void Reports_Success_Termination()
        {
            var bootCode = new BootCode(_data);
            var bootCodeSuccessfulTermination = new BootCode(_dataSuccessfulTermination);

            bootCode.HadSuccessfulTermination.Should().BeFalse();
            bootCodeSuccessfulTermination.HadSuccessfulTermination.Should().BeTrue();
        }
    }
}