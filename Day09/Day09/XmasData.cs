using System;
using System.Linq;

namespace Day09
{
    public class XmasData
    {
        private ulong[] _data;

        public ulong InvalidNumber { get; private set; }
        public ulong EncryptionWeakness { get; private set; }

        public XmasData(string[] data, int preambleLength)
        {
            _data = Array.ConvertAll(
                data,
                new Converter<string, ulong>(StringToULong)
            );

            InvalidNumber = DetermineInvalidNumber(preambleLength);

            for (var i = 0; i < _data.Length; i++)
            {
                var sum = _data[i];
                for (var j = i + 1; j < _data.Length; j++)
                {
                    sum += _data[j];

                    if (sum == InvalidNumber)
                    {
                        var contiguousNumbers = _data.Skip(i).Take(j - i).ToArray();
                        EncryptionWeakness = contiguousNumbers.Max() + contiguousNumbers.Min();
                        return;
                    }

                    if (sum > InvalidNumber)
                    {
                        break;
                    }
                }
            }
        }

        private ulong StringToULong(string input)
        {
            return ulong.Parse(input);
        }

        private ulong DetermineInvalidNumber(int preambleLength)
        {
            for (var i = preambleLength; i < _data.Length; i++)
            {
                bool hasValid = false;
                for (var j = i - preambleLength; j < i; j++)
                {
                    for (var k = j + 1; k < i; k++)
                    {
                        if (_data[j] + _data[k] == _data[i])
                        {
                            hasValid = true;
                        }
                    }
                }

                if (!hasValid)
                {
                    return _data[i];
                }
            }

            return 0;
        }
    }
}
