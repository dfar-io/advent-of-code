using System;

namespace Day05
{
    public class BoardingPass
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int SeatId
        { 
            get { return Row * 8 + Column; }
        }

        public BoardingPass(string data)
        {
            var rowRange = new int[] { 0, 127 };
            var colRange = new int[] { 0, 7 };

            foreach (char c in data)
            {
                switch (c)
                {
                    case 'F':
                        rowRange[1] = Midpoint(rowRange);
                        break;
                    case 'B':
                        rowRange[0] = Midpoint(rowRange) + 1;
                        break;
                    case 'L':
                        colRange[1] = Midpoint(colRange);
                        break;
                    case 'R':
                        colRange[0] = Midpoint(colRange) + 1;
                        break;
                }
            }

            Row = rowRange[0];
            Column = colRange[0];
        }

        public override string ToString()
        {
            return $"row:{Row}, col:{Column}, seatId:{SeatId}";
        }

        private int Midpoint(int[] range)
        {
            return (range[0] + range[1]) / 2;
        }
    }
}
