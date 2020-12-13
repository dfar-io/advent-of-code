using FluentAssertions;
using NUnit.Framework;

namespace Day10.Tests
{
    public class DeviceTests
    {
        private Device _device;

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
    }
}