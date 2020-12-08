using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day07.Tests
{
    public class Tests
    {
        private const string TestCaseData1 = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
        private const string TestCaseData2 = "dark orange bags contain 3 bright white bags, 4 muted yellow bags.";
        private const string TestCaseData3 = "bright white bags contain 1 shiny gold bag.";
        private const string TestCaseData4 = "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
        private const string TestCaseData5 = "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.";
        private const string TestCaseData6 = "dark olive bags contain 3 faded blue bags, 4 dotted black bags.";
        private const string TestCaseData7 = "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.";
        private const string TestCaseData8 = "faded blue bags contain no other bags.";
        private const string TestCaseData9 = "dotted black bags contain no other bags.";


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(TestCaseData1, "light red")]
        [TestCase(TestCaseData2, "dark orange")]
        [TestCase(TestCaseData3, "bright white")]
        [TestCase(TestCaseData4, "muted yellow")]
        [TestCase(TestCaseData5, "shiny gold")]
        [TestCase(TestCaseData6, "dark olive")]
        [TestCase(TestCaseData7, "vibrant plum")]
        [TestCase(TestCaseData8, "faded blue")]
        [TestCase(TestCaseData9, "dotted black")]
        public void Reads_Color_From_Data(string rule, string color)
        {
            var bag = new Bag(rule);

            bag.Color.Should().Be(color);
        }
    }
}