using AoCHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_09 : BaseDay
    {
        private readonly List<double> _input;

        public Day_09()
        {
            _input = File.ReadAllLines(InputFilePath).Select(line => double.Parse(line)).ToList();
        }

        public override string Solve_1()
        {
            for (int t = 25; t < _input.Count; t++)
            {
                if (Find(_input.Skip(t - 25).Take(25).ToList(), _input[t]) != true)
                {
                    return _input[t].ToString();
                }
            }
            throw new SolvingException();
        }

        public override string Solve_2()
        {
            double target = double.Parse(Solve_1());

            for (int i = 0; i < _input.Count; i++)
            {
                for (int j = 1; j < _input.Count - i; j++)
                {
                    List<double> range = _input.GetRange(i, j);

                    if (range.Sum() == target)
                    {
                        return (range.Min() + range.Max()).ToString();
                    }

                    if (range.Sum() > target)
                    {
                        break;
                    }
                }
            }
            throw new SolvingException();
        }

        private static bool Find(List<double> validNumbers, double target)
        {
            for (int i = 0; i < validNumbers.Count; i++)
            {
                for (int j = i; j < validNumbers.Count; j++)
                {
                    if (validNumbers[i] + validNumbers[j] == target)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }

}

