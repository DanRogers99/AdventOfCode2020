using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_06 : BaseDay
    {
        private readonly List<List<List<char>>> _groups;

        public Day_06()
        {
            _groups = new List<List<List<char>>>();

            var group = new List<List<char>>();

            foreach (var line in File.ReadAllLines(InputFilePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _groups.Add(group);
                    group = new List<List<char>>();
                    continue;
                }

                group.Add(line.Distinct().ToList());
            }

            _groups.Add(group);
        }

        public override string Solve_1()
        {
            var count = 0;
            foreach (var group in _groups)
            {
                count += group.SelectMany(x => x).ToList().Distinct().Count();
            }

            return count.ToString();
        }

        public override string Solve_2()
        {
            var count = 0;
            foreach (var group in _groups)
            {
                count += group.SelectMany(x => x).ToList().GroupBy(letter => letter).Where(letter => letter.Count() == group.Count).Count();
            }

            return count.ToString();
        }

    }
}
