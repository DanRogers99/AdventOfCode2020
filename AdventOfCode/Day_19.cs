using AoCHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_19 : BaseDay
    {
        private readonly List<string> _input;
        private readonly Dictionary<int, string> _rules;
        public Day_19()
        {
            List<string> _file = File.ReadAllLines(InputFilePath).ToList();

            int fileSplitIndex = _file.FindIndex(x => x == "");

            _input = _file.Skip(fileSplitIndex + 1).ToList();
            _rules = new Dictionary<int, string>();

            foreach (var item in _file.Take(fileSplitIndex).Select(x => x.Split(": ")))
            {
                _rules.Add(int.Parse(item[0]), item[1]);
            }
        }

        public override string Solve_1()
        {
            var dd = _rules;

            var a = _rules.Where(x => x.Value.Contains("a")).FirstOrDefault();


            var u = dd.Where(x => x.Value.Contains(a.Key.ToString())).ToList();



            var b = _input.Where(x => x == "b").FirstOrDefault();




            return "";

        }

        

        public override string Solve_2()
        {
            return "";
        }

    }
}


