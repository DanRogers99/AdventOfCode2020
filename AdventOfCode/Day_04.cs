using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_04 : BaseDay
    {
        private readonly List<Dictionary<string, string>> _input;

        public Day_04()
        {
            _input = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
            };

            var index = 0;
            foreach (var line in File.ReadAllLines(InputFilePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _input.Add(new Dictionary<string, string>());
                    ++index;
                    continue;
                }

                foreach (var word in line.Split(' '))
                {
                    var pair = word.Split(':');
                    _input[index][pair[0]] = pair[1];
                }
            }
        }

        public override string Solve_1()
        {
            int count = 0;

            foreach (var i in _input)
            {
                if (i.ContainsKey("ecl")
                    && i.ContainsKey("pid")
                    && i.ContainsKey("eyr")
                    && i.ContainsKey("hcl")
                    && i.ContainsKey("byr")
                    && i.ContainsKey("iyr")
                    && i.ContainsKey("hgt"))
                {
                    count++;
                }
            }

            return count.ToString();
        }

        public override string Solve_2()
        {
            int count = 0;

            foreach (var i in _input)
            {
                if (!i.TryGetValue("byr", out string byrStr)
                    || !int.TryParse(byrStr, out int byr)
                    || byr < 1920
                    || byr > 2002)
                {
                    continue;
                }

                if (!i.TryGetValue("iyr", out string iyrStr)
                    || !int.TryParse(iyrStr, out int iyr)
                    || iyr < 2010
                    || iyr > 2020)
                {
                    continue;
                }

                if (!i.TryGetValue("eyr", out string eyrStr)
                    || !int.TryParse(eyrStr, out int eyr)
                    || eyr < 2020
                    || eyr > 2030)
                {
                    continue;
                }

                if (i.TryGetValue("hgt", out string hgtStr))
                {
                    switch (hgtStr[^2..])
                    {
                        case "cm":
                            if (!int.TryParse(hgtStr[0..^2], out int hgtcm)
                                || hgtcm < 150
                                || hgtcm > 193)
                            {
                                continue;
                            }
                            break;
                        case "in":
                            if (!int.TryParse(hgtStr[0..^2], out int hgtIn)
                                || hgtIn < 59
                                || hgtIn > 76)
                            {
                                continue;
                            }
                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    continue;
                }

                if (!i.TryGetValue("hcl", out string hclStr)
                    || !Regex.Match(hclStr, "^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$", RegexOptions.IgnoreCase).Success)
                {
                    continue;
                }

                if (!i.TryGetValue("ecl", out string eclStr)
                    || !eclStr.Equals("amb")
                    && !eclStr.Equals("blu")
                    && !eclStr.Equals("amb")
                    && !eclStr.Equals("brn")
                    && !eclStr.Equals("gry")
                    && !eclStr.Equals("grn")
                    && !eclStr.Equals("hzl")
                    && !eclStr.Equals("oth"))
                {
                    continue;
                }

                if (!i.TryGetValue("pid", out string pidStr)
                    || !Regex.Match(pidStr, "^\\d{9}$", RegexOptions.IgnoreCase).Success)
                {
                    continue;
                }

                count++;
            }

            return count.ToString();
        }

    }
}
