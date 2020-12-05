using System;
using System.IO;

namespace Day04
{
    public static class PassportReader
    {
        public static Passport[] ReadData(string filename)
        {
            var fileData = File.ReadAllText(filename);
            var passportDatas = fileData.Split("\n\n");
            return Array.ConvertAll(passportDatas, new Converter<string, Passport>(StringToPassport));
        }

        // delegate to convert using the PasswordRecord converter
        public static Passport StringToPassport(string record)
        {
            return new Passport(record);
        }
    }
}
