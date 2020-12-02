using System;
using System.IO;

namespace Day02
{
    public static class PasswordRecordReader
    {
        public static PasswordRecord[] ReadData(string filePath)
        {
            var records = File.ReadAllLines(filePath);
            return Array.ConvertAll(records, new Converter<string, PasswordRecordPartTwo>(StringToPasswordRecord));
        }

        // delegate to convert using the PasswordRecord converter
        public static PasswordRecordPartTwo StringToPasswordRecord(string record)
        {
            return new PasswordRecordPartTwo(record);
        }
    }
}
