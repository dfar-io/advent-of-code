using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Day01.Tests
{
    public class ExpenseReportReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Read_ExpenseReport_From_Txt_To_List()
        {
            var expenses = ExpenseReportReader.ReadExpenseReport("test-expense-report.txt");

            expenses.Should().HaveCount(6);
        }

        [Test]
        public void Should_Throw_ArgumentException_With_NonNumeric_Data()
        {
            Action act = () => ExpenseReportReader.ReadExpenseReport("test-expense-report-bad-data.txt");

            act.Should().Throw<FormatException>();
        }

        [Test]
        public void Should_Throw_FileNotFoundException()
        {
            Action act = () => ExpenseReportReader.ReadExpenseReport("non-existing-data.txt");

            act.Should().Throw<FileNotFoundException>();
        }
    }
}