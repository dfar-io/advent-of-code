using System;
using System.Linq;

namespace Day02
{
    public abstract record PasswordRecord
    {
        // public int MinimumLetterCount { get; }
        // public int MaximumLetterCount { get; }
        public char Letter { get; private set; }
        public string Password { get; private set; }

        public PasswordRecord(string record)
        {
            Letter = char.Parse(
                record.Substring(
                    record.IndexOf(":") - 1,
                    1
                )
            );
            Password = record.Substring(record.LastIndexOf(" ") + 1);
        }

        public abstract bool IsValid();
    }
}