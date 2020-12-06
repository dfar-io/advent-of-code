using System;
using System.IO;
using System.Linq;

namespace Day06
{
    public static class GroupReader
    {
        public static Group[] ReadData(string filename)
        {
            var fileData = File.ReadAllText(filename);
            var groupDatas = fileData.Split("\n\n");
            return Array.ConvertAll(groupDatas, new Converter<string, Group>(StringToGroup));
        }

        private static Group StringToGroup(string record)
        {
            return new Group(record);
        }
    }
}
