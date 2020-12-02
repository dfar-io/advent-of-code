using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day01.Tests
{
    public class ExpenseReportProcessorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Return_Two_Values()
        {
            var expenses = new int[]
            {
                1721,
                299
            };

            var result = ExpenseReportProcessor.Find2020SumEntriesForTwo(expenses);

            result.Should().BeEquivalentTo(new int[] { 1721, 299 });
        }

        [Test]
        public void Return_Three_Values()
        {
            var expenses = new int[]
            {
                979,
                366,
                675
            };

            var result = ExpenseReportProcessor.Find2020SumEntriesForThree(expenses);

            result.Should().BeEquivalentTo(new int[] { 979, 366, 675 });
        }

        [Test]
        public void Return_Null_If_Not_Found()
        {
            var expenses = new int[]
            {
                1721,
                300
            };

            var result = ExpenseReportProcessor.Find2020SumEntriesForTwo(expenses);

            result.Should().BeNull();
        }
    }
}