using FluentAssertions;
using NUnit.Framework;

namespace Day04.Tests
{
    public class PassportTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Converts_From_String_Data()
        {
            var passport = new Passport("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\nbyr:1937 iyr:2017 cid:147 hgt:183cm");

            passport.BirthYear.Should().Be("1937");
            passport.IssueYear.Should().Be("2017");
            passport.ExpirationYear.Should().Be("2020");
            passport.Height.Should().Be("183cm");
            passport.HairColor.Should().Be("#fffffd");
            passport.EyeColor.Should().Be("gry");
            passport.PassportId.Should().Be("860033327");
            passport.CountryId.Should().Be("147");
        }

        [Test]
        [TestCase("eyr:1972 cid:100\nhcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926", false)]
        [TestCase("iyr:2019\nhcl:#602927 eyr:1967 hgt:170cm\necl:grn pid:012533040 byr:1946", false)]
        [TestCase("hcl:dab227 iyr:2012\necl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277", false)]
        [TestCase("hgt:59cm ecl:zzz\neyr:2038 hcl:74454a iyr:2023\npid:3556412378 byr:2007", false)]
        [TestCase("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\nhcl:#623a2f", true)]
        [TestCase("eyr:2029 ecl:blu cid:129 byr:1989\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm", true)]
        [TestCase("hcl:#888785\nhgt:164cm byr:2001 iyr:2015 cid:88\npid:545766238 ecl:hzl\neyr:2022", true)]
        [TestCase("iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719", true)]
        public void Returns_Validity(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsValid().Should().Be(result);
        }

        [Test]
        [TestCase("byr:2002", true)]
        [TestCase("byr:2003", false)]
        public void Returns_Is_BirthYear_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsBirthYearValid().Should().Be(result);
        }

        [Test]
        [TestCase("iyr:2009", false)]
        [TestCase("iyr:2010", true)]
        public void Returns_Is_IssueYear_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsIssueYearValid().Should().Be(result);
        }

        [Test]
        [TestCase("eyr:2019", false)]
        [TestCase("eyr:2020", true)]
        public void Returns_Is_ExpirationYear_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsExpirationYearValid().Should().Be(result);
        }

        [Test]
        [TestCase("hgt:60in", true)]
        [TestCase("hgt:190cm", true)]
        [TestCase("hgt:190in", false)]
        [TestCase("hgt:190", false)]
        public void Returns_Is_Height_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsHeightValid().Should().Be(result);
        }

        [Test]
        [TestCase("hcl:#123abc", true)]
        [TestCase("hcl:#123abz", false)]
        [TestCase("hcl:123abc", false)]
        public void Returns_Is_HairColor_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsHairColorValid().Should().Be(result);
        }

        [Test]
        [TestCase("ecl:brn", true)]
        [TestCase("ecl:wat", false)]
        public void Returns_Is_EyeColor_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsEyeColorValid().Should().Be(result);
        }

        [Test]
        [TestCase("pid:000000001", true)]
        [TestCase("pid:0123456789", false)]
        public void Returns_Is_Passport_Valid(string data, bool result)
        {
            var passport = new Passport(data);

            passport.IsPassportIdValid().Should().Be(result);
        }
    }
}