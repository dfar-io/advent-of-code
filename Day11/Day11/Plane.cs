using System;
using System.Linq;

namespace Day11
{
    public class Plane
    {
        private char[,] _currentState;

        public char[,] InitialState { get; private set; }
        public char[,] FinalState { get; set; }
        public int OccupiedSeatCount { get; set; }

        public Plane(string[] data, uint steps = 0)
        {
            _currentState = ConvertData(data);
            InitialState = ConvertData(data);

            if (steps == 0)
            {
                while (true)
                {
                    FinalState = Process(_currentState);
                    // checks if equal
                    if (AreArraysEqual(FinalState, _currentState))
                    {
                        OccupiedSeatCount = GetOccupiedSeatCount(FinalState);
                        return;
                    }
                    _currentState = FinalState;
                }
            }

            // process for defined steps
            while (steps > 0)
            {
                FinalState = Process(_currentState);
                _currentState = FinalState;
                steps--;
            }
        }

        private int GetOccupiedSeatCount(char[,] finalState)
        {
            var width = finalState.GetLength(0);
            var length = finalState.GetLength(1);
            var sum = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    sum += finalState[i,j] == '#' ? 1 : 0;
                }
            } 
            return sum;
        }

        private bool AreArraysEqual(char[,] a1, char[,] a2)
        {
            return a1.Rank == a2.Rank &&
                Enumerable.Range(0, a1.Rank)
                          .All(dimension => a1.GetLength(dimension) == a2.GetLength(dimension)) &&
                          a1.Cast<char>().SequenceEqual(a2.Cast<char>());
        }

        private char[,] Process(char[,] currentState)
        {
            var width = currentState.GetLength(0);
            var length = currentState.GetLength(1);
            var newState = new char[width,length];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    newState[i, j] = ProcessField(currentState, i, j);
                }
            } 

            return newState;
        }

        private static char ProcessField(char[,] currentState, int i, int j)
        {
            var character = currentState[i, j];   
            switch (character)
            {
                case 'L':
                    return AdjacentOccupiedCount(currentState, i, j) == 0 ? '#' : 'L';
                case '#':
                    return AdjacentOccupiedCount(currentState, i, j) >= 4 ? 'L' : '#';
                default:
                    return '.';
            }
        }

        private static int AdjacentOccupiedCount(char[,] currentState, int row, int col)
        {
            var rows = currentState.GetLength(0);
            var cols = currentState.GetLength(1);
            var sum = 0;
            
            for (int ro = -1; ro <= 1; ro++)
            {
                for (int co = -1; co <= 1; co++)
                {
                    // don't count self
                    if (ro == 0 && co == 0) { continue; }

                    int rOffset = row + ro;
                    int cOffset = col + co;

                    // Points to a space that exists
                    if (rOffset >= 0 && rOffset < rows && cOffset >= 0 && cOffset < cols)
                    {
                        sum += currentState[rOffset,cOffset] == '#' ? 1 : 0;
                    }
                }
            }

            return sum;
        }

        private char[,] ConvertData(string[] data)
        {
            var width = data[0].Length;
            var result = new char[data.Length, width];
            for (int row = 0; row < data.Length; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    result[row,col] = data[row][col];
                }
            }

            return result;
        }
    }
}
