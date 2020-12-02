using System;
using System.Linq;

namespace Day02
{
    public record PasswordRecordPartOne : PasswordRecord
    {
        public int MinimumLetterCount { get; }
        public int MaximumLetterCount { get; }

        public PasswordRecordPartOne(string record) : base(record)
        {
            MinimumLetterCount = int.Parse(record.Substring(0, record.IndexOf("-")));
            MaximumLetterCount = int.Parse(
                record.Substring(
                    record.IndexOf("-") + 1,
                    record.IndexOf(" ") - 2
                )
            );
        }

        public override bool IsValid()
        {
            var letterCount = Password.ToCharArray().Count(c => c == Letter);
            return MinimumLetterCount <= letterCount && letterCount <= MaximumLetterCount;
        }
    }
}