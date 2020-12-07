using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_07 : BaseDay
    {
        private readonly List<KeyValuePair<string, string>> _bags;

        public Day_07()
        {
            _bags = new List<KeyValuePair<string, string>>();

            foreach (var line in File.ReadAllLines(InputFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var bag = line.Split("contain");

                    foreach (var item in bag[1].Split(","))
                    {
                        if (int.TryParse(item.Trim().Split()[0], out int amounts))
                        {
                            for (int i = 0; i < amounts; i++)
                            {
                                _bags.Add(new KeyValuePair<string, string>(bag[0].Trim(), item.Trim()[1..].Trim()));
                            }
                        }
                        else
                        {
                            _bags.Add(new KeyValuePair<string, string>(bag[0].Trim(), bag[1].Trim()));
                        }
                    }
                }
            }
        }

        public override string Solve_1()
        {
            var allBags = _bags.Where(x => x.Value.Contains("shiny gold bag")).Select(x => x.Key).Distinct().ToList();

            for (int i = 0; i < allBags.Count; i++)
            {
                allBags.AddRange(_bags.Where(x => x.Value.Contains(allBags.ElementAt(i)[0..^1])).Select(x => x.Key).Distinct().Where(item => !allBags.Contains(item)));
            }

            return allBags.Count.ToString();
        }

        public override string Solve_2()
        {
            var allBags = _bags.Where(x => x.Key.Contains("shiny gold bag")).Select(x => x.Value).ToList();

            for (int i = 0; i < allBags.Count; i++)
            {
                allBags.AddRange(_bags.Where(x => x.Key.Contains(allBags.ElementAt(i)[0..^1]) && x.Value != "no other bags.").Select(x => x.Value));
            }
        
            return allBags.Count.ToString();
        }

}
}
