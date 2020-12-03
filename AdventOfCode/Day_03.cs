using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_03 : BaseDay
    {
        private readonly string _input;
        private readonly int _totalchar;
        private readonly List<char[]> _inputList;

        public Day_03()
        {
            _input = File.ReadAllText(InputFilePath);
            _inputList = new List<char[]>();

            foreach (var line in _input.Split("\n"))
            {
                _inputList.Add(line.ToCharArray());
            }

            _totalchar = _inputList[0].Length;
        }

        public override string Solve_1()
        {
            return CalculateTrees(3, 1).ToString();
        }

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

            for (int i = 0; i < _inputList.Count - 1; i++)
            {
                if (_inputList[i][charCounter] == '#')
                {
                    treecount++;
                }

                charCounter = charCounter + right;

                if (charCounter >= _totalchar)
                {
                    charCounter = charCounter - _totalchar;
                }

                i = i + down - 1;
            }

            return treecount;
        }
    }
}
