using System;
using System.IO;
using System.Linq;

namespace Day04
{
    public static class PassportProcessor
    {
        public static int FindValidPassportCount(string filename)
        {
            var passports = PassportReader.ReadData(filename);

            return passports.Where(p => p.IsValid()).Count();
        }
    }
}
