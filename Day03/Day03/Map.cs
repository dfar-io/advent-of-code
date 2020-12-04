using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class Map
    {
        private bool[,] _map;

        public Map(string[] data)
        {
            var rowLength = data.First().Length;
            _map = new bool[data.Length, rowLength];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (data[i][j] == '#')
                    {
                        _map[i,j] = true;
                    }
                }
            }
        }

        public int GetTreeCount(int right, int down)
        {
            int y = 0;
            int result = 0;

            var mapHeight = _map.GetLength(0);
            var mapWidth = _map.GetLength(1);

            for (int x = 0; x < mapHeight; x+=down)
            {
                if (_map[x,y]) { result++; }

                y += right;
                // loop around if past the width
                y = y % mapWidth;
            }

            return result;
        }
    }
}
