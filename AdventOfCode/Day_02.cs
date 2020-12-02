using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_02 : BaseDay
    {
        private readonly string _input;
        private readonly List<string> _stringList;

        public Day_02()
        {
            _input = File.ReadAllText(InputFilePath);
            _stringList = _input.Split("\n").ToList();
        }

        public override string Solve_1()
        {
            int counter = 0;
            for (int i = 0; i < _stringList.Count; i++)
            {
                var data = _stringList[i].Split(" ");

                var word = data[2];
                var letter = data[1][0];
                var range = data[0].Split("-").Select(t => int.Parse(t)).ToArray();

                var m = word.Count(s => s == letter);

                if (range[0] <= m && range[1] >= m)
                {
                    counter++;
                }
            }
            return counter.ToString();
        }

        public override string Solve_2()
        {
            int counter = 0;
            for (int i = 0; i < _stringList.Count; i++)
            {
                var data = _stringList[i].Split(" ");

                var word = data[2];
                var letter = data[1][0];
                var range = data[0].Split("-").Select(t => int.Parse(t)).ToArray();

                if (word.ToCharArray()[range[0] - 1] == letter ^ word.ToCharArray()[range[1] - 1] == letter)
                {
                    counter++;
                }
            }
            return counter.ToString();
        }
    }
}
