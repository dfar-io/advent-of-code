using FluentAssertions;
using NUnit.Framework;

namespace Day10.Tests
{
    public class DeviceTests
    {
        private Device _device;
        private Device _device2;
        private Device _device3;

        [SetUp]
        public void Setup()
        {
            _device = new Device(new JoltageAdapter[] {
                new JoltageAdapter(16),
                new JoltageAdapter(10),
                new JoltageAdapter(15),
                new JoltageAdapter(5),
                new JoltageAdapter(1),
                new JoltageAdapter(11),
                new JoltageAdapter(7),
                new JoltageAdapter(19),
                new JoltageAdapter(6),
                new JoltageAdapter(12),
                new JoltageAdapter(4),
            });

            _device2 = new Device(new JoltageAdapter[] {
                new JoltageAdapter(28),
                new JoltageAdapter(33),
                new JoltageAdapter(18),
                new JoltageAdapter(42),
                new JoltageAdapter(31),
                new JoltageAdapter(14),
                new JoltageAdapter(46),
                new JoltageAdapter(20),
                new JoltageAdapter(48),
                new JoltageAdapter(47),
                new JoltageAdapter(24),
                new JoltageAdapter(23),
                new JoltageAdapter(49),
                new JoltageAdapter(45),
                new JoltageAdapter(19),
                new JoltageAdapter(38),
                new JoltageAdapter(39),
                new JoltageAdapter(11),
                new JoltageAdapter(1),
                new JoltageAdapter(32),
                new JoltageAdapter(25),
                new JoltageAdapter(35),
                new JoltageAdapter(8),
                new JoltageAdapter(17),
                new JoltageAdapter(7),
                new JoltageAdapter(9),
                new JoltageAdapter(4),
                new JoltageAdapter(2),
                new JoltageAdapter(34),
                new JoltageAdapter(10),
                new JoltageAdapter(3)
            });

            _device3 = new Device(new JoltageAdapter[]
            {
                new JoltageAdapter(2),
                new JoltageAdapter(3),
                new JoltageAdapter(4),
                new JoltageAdapter(5),
                new JoltageAdapter(6),
                new JoltageAdapter(9)
            });
        }

        [Test]
        public void Initializes()
        {
            _device.JoltageAdapterRating.Should().Be(22);
        }

        [Test]
        public void Calculates_Jolt_Differences()
        {
            _device.JoltDifferences[0].Should().Be(7);
            _device.JoltDifferences[2].Should().Be(5);
        }

        [Test]
        public void Calculates_Combinations()
        {
            _device.Combinations.Should().Be(8);
            _device2.Combinations.Should().Be(19208);
            _device3.Combinations.Should().Be(11);
        }
    }
}