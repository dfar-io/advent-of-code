using FluentAssertions;
using NUnit.Framework;

namespace Day06.Tests
{
    public class GroupTests
    {
        private const string Group1 = "abc";
        private const string Group2 = "a\nb\nc";
        private const string Group3 = "ab\nac";
        private const string Group4 = "a\na\na\na";
        private const string Group5 = "b";


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(Group1, 1)]
        [TestCase(Group2, 3)]
        [TestCase(Group3, 2)]
        [TestCase(Group4, 4)]
        [TestCase(Group5, 1)]
        public void Initializes_Correct_PeopleCount(string data, int result)
        {
            var group = new Group(data);

            group.PeopleCount.Should().Be(result); 
        }

        [Test]
        [TestCase(Group1, new char[] {'a', 'b', 'c'})]
        [TestCase(Group2, new char[] {'a', 'b', 'c'})]
        [TestCase(Group3, new char[] {'a', 'b', 'c'})]
        [TestCase(Group4, new char[] {'a'})]
        [TestCase(Group5, new char[] {'b'})]
        public void Initializes_Correct_QuestionsAnsweredYesByAnyone(string data, char[] result)
        {
            var group = new Group(data);

            group.QuestionsAnsweredYesByAnyone.Should().BeEquivalentTo(result); 
        }

        [Test]
        [TestCase(Group1, new char[] {'a', 'b', 'c'})]
        [TestCase(Group2, new char[] {})]
        [TestCase(Group3, new char[] {'a'})]
        [TestCase(Group4, new char[] {'a'})]
        [TestCase(Group5, new char[] {'b'})]
        public void Initializes_Correct_QuestionsAnsweredYesByEveryone(string data, char[] result)
        {
            var group = new Group(data);

            group.QuestionsAnsweredYesByEveryone.Should().BeEquivalentTo(result); 
        }
    }
}