using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    public class Passport
    {
        public string BirthYear { get; private set; }
        public string IssueYear { get; private set; }
        public string ExpirationYear { get; private set; }
        public string Height { get; private set; }
        public string HairColor { get; private set; }
        public string EyeColor { get; private set; }
        public string PassportId { get; private set; }
        public string CountryId { get; private set; }

        public Passport(string data)
        {
            var entries = data.Split(new string[] { " ", "\n" }, StringSplitOptions.None);

            foreach (var entry in entries)
            {
                var splitEntry = entry.Split(":");
                var key = splitEntry[0];
                var value = splitEntry[1];

                switch (key)
                {
                    case "byr":
                        BirthYear = value;
                        break;
                    case "iyr":
                        IssueYear = value;
                        break;
                    case "eyr":
                        ExpirationYear = value;
                        break;
                    case "hgt":
                        Height = value;
                        break;
                    case "hcl":
                        HairColor = value;
                        break;
                    case "ecl":
                        EyeColor = value;
                        break;
                    case "pid":
                        PassportId = value;
                        break;
                    case "cid":
                        CountryId = value;
                        break;  
                }
            }
        }

        public bool IsValid()
        {
            return IsBirthYearValid() &&
                   IsIssueYearValid() &&
                   IsExpirationYearValid() &&
                   IsHeightValid() &&
                   IsHairColorValid() &&
                   IsEyeColorValid() &&
                   IsPassportIdValid();
        }

        public bool IsPassportIdValid()
        {
            return !string.IsNullOrWhiteSpace(PassportId) &&
                    PassportId.Length == 9 &&
                    int.TryParse(PassportId, out _);
        }

        public bool IsEyeColorValid()
        {
            return !string.IsNullOrWhiteSpace(EyeColor) &&
                    new List<string>
                    {
                        "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
                    }.Contains(EyeColor);
        }

        public bool IsHairColorValid()
        {
            return !string.IsNullOrWhiteSpace(HairColor) &&
                    HairColor.Length == 7 &&
                    Regex.Matches(HairColor, @"[#]{1}[0-9a-f]{6}").Any();
        }

        public bool IsHeightValid()
        {
            if (string.IsNullOrWhiteSpace(Height) || Height.Length < 4) { return false ;}
            var unit = Height.Substring(Height.Length - 2);

            switch (unit)
            {
                case "in":
                    if (!int.TryParse(Height.Replace("in", ""), out var inches)) { return false; };
                    return 59 <= inches && inches <= 76;
                case "cm":
                    if (!int.TryParse(Height.Replace("cm", ""), out var centimeters)) { return false; };
                    return 150 <= centimeters && centimeters <= 193;
            }

            return false;
        }

        public bool IsExpirationYearValid()
        {
            return !string.IsNullOrWhiteSpace(ExpirationYear) &&
                    int.TryParse(ExpirationYear, out _) &&
                    ExpirationYear.Length == 4 &&
                    2020 <= int.Parse(ExpirationYear) && int.Parse(ExpirationYear) <= 2030;
        }

        public bool IsIssueYearValid()
        {
            return !string.IsNullOrWhiteSpace(IssueYear) &&
                    int.TryParse(IssueYear, out _) &&
                    IssueYear.Length == 4 &&
                    2010 <= int.Parse(IssueYear) && int.Parse(IssueYear) <= 2020;
        }

        public bool IsBirthYearValid()
        {
            return !string.IsNullOrWhiteSpace(BirthYear) &&
                    int.TryParse(BirthYear, out _) &&
                    BirthYear.Length == 4 &&
                    1920 <= int.Parse(BirthYear) && int.Parse(BirthYear) <= 2002;
        }
    }
}