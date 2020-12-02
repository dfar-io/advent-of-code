using System;
using System.Linq;

namespace Day02
{
    public record PasswordRecordPartTwo : PasswordRecord
    {
        public int Position1 { get; }
        public int Position2 { get; }

        public PasswordRecordPartTwo(string record) : base(record)
        {
            Position1 = int.Parse(record.Substring(0, record.IndexOf("-")));
            Position2 = int.Parse(
                record.Substring(
                    record.IndexOf("-") + 1,
                    record.IndexOf(" ") - 2
                )
            );
        }

        public override bool IsValid()
        {
            return Password[Position1 - 1].Equals(Letter) ^
                   Password[Position2 - 1].Equals(Letter);
        }
    }
}