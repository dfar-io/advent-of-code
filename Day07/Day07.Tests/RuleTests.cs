using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day07.Tests
{
    public class RuleTests
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
        public void Reads_Color_From_Data(string ruleData, string color)
        {
            var rule = new Rule(ruleData);

            rule.Color.Should().Be(color);
        }

        [Test]
        [TestCase(TestCaseData1, 2)]
        [TestCase(TestCaseData2, 2)]
        [TestCase(TestCaseData3, 1)]
        [TestCase(TestCaseData4, 2)]
        [TestCase(TestCaseData5, 2)]
        [TestCase(TestCaseData6, 2)]
        [TestCase(TestCaseData7, 2)]
        [TestCase(TestCaseData8, 0)]
        [TestCase(TestCaseData9, 0)]
        public void Reads_Correct_ContainCount_From_Data(string ruleData, int count)
        {
            var rule = new Rule(ruleData);

            rule.Contains.Should().HaveCount(count);
        }

        [Test]
        public void Reads_Contain_From_Data()
        {
            var rule = new Rule(TestCaseData1);

            rule.Contains.Should().HaveCount(2);
            rule.Contains[0].Should().Be(("bright white", 1));
            rule.Contains[1].Should().Be(("muted yellow", 2));
        }

        [Test]
        public void Correctly_Returns_CanContain()
        {
            var rules = new Rule[]
            {
                new Rule(TestCaseData1),
                new Rule(TestCaseData2),
                new Rule(TestCaseData3),
                new Rule(TestCaseData4),
                new Rule(TestCaseData5),
                new Rule(TestCaseData6),
                new Rule(TestCaseData7),
                new Rule(TestCaseData8),
                new Rule(TestCaseData9),
            };

            rules[0].CanContainColor(rules, "shiny gold").Should().BeTrue();
            rules[1].CanContainColor(rules, "shiny gold").Should().BeTrue();
            rules[2].CanContainColor(rules, "shiny gold").Should().BeTrue();
            rules[3].CanContainColor(rules, "shiny gold").Should().BeTrue();
            rules[4].CanContainColor(rules, "shiny gold").Should().BeFalse();
            rules[5].CanContainColor(rules, "shiny gold").Should().BeFalse();
            rules[6].CanContainColor(rules, "shiny gold").Should().BeFalse();
            rules[7].CanContainColor(rules, "shiny gold").Should().BeFalse();
            rules[8].CanContainColor(rules, "shiny gold").Should().BeFalse();
        }

        [Test]
        public void Correctly_Returns_BagCount()
        {
            var rules = new Rule[]
            {
                new Rule(TestCaseData1),
                new Rule(TestCaseData2),
                new Rule(TestCaseData3),
                new Rule(TestCaseData4),
                new Rule(TestCaseData5),
                new Rule(TestCaseData6),
                new Rule(TestCaseData7),
                new Rule(TestCaseData8),
                new Rule(TestCaseData9),
            };

            rules[4].BagCount(rules).Should().Be(32);
        }
    }
}