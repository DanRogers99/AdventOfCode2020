using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_03 : BaseDay
    {
        private readonly List<List<char>> _inputList;
        private readonly int _totalchar;

        public Day_03()
        {
            _inputList = File.ReadAllText(InputFilePath).Split("\n").Select(line => line.ToCharList()).ToList();
            _totalchar = _inputList[0].Count();
        }

        public override string Solve_1() => CalculateTrees(3, 1).ToString();

        public override string Solve_2()
        {
            long c1 = CalculateTrees(1, 1);
            long c2 = CalculateTrees(3, 1);
            long c3 = CalculateTrees(5, 1);
            long c4 = CalculateTrees(7, 1);
            long c5 = CalculateTrees(1, 2);

            return (c1 * c2 * c3 * c4 * c5).ToString();
        }

        private int CalculateTrees(int right, int down)
        {
            int treecount = 0;
            int charCounter = 0;

            for (int rowCount = 0; rowCount < _inputList.Count - 1; rowCount++)
            {
                if (_inputList[rowCount][charCounter] == '#')
                {
                    treecount++;
                }

                charCounter += right;

                if (charCounter >= _totalchar)
                {
                    charCounter -= _totalchar;
                }

                rowCount += down - 1;
            }

            return treecount;
        }
    }
}
