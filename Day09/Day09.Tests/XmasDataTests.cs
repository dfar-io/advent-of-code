using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Day09.Tests
{
    public class XmasDataTests
    {
        private string[] _data;

        [SetUp]
        public void Setup()
        {
            _data = new string[]
            {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576"
            };
        }

        [Test]
        public void Calculates_Invalid_Number()
        {
            var xmasData = new XmasData(_data, 5);

            xmasData.InvalidNumber.Should().Be(127);
        }

        [Test]
        public void Calculates_Encryption_Weakness()
        {
            var xmasData = new XmasData(_data, 5);

            xmasData.EncryptionWeakness.Should().Be(62);
        }
    }
}