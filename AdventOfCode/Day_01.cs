using AoCHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_01 : BaseDay
    {
        private readonly string _input;
        private readonly List<int> _numbersList;

        public Day_01()
        {
            _input = File.ReadAllText(InputFilePath);
            _numbersList = _input.Split("\r\n").Select(t => int.Parse(t)).ToList();
        }

        public override string Solve_1()
        {
            for (int i = 0; i < _numbersList.Count; i++)
            {
                for (int j = i; j < _numbersList.Count; j++)
                {
                    if (_numbersList[i] + _numbersList[j] == 2020)
                    {
                        return (_numbersList[i] * _numbersList[j]).ToString();
                    }
                }
            }
            throw new SolvingException();
        }

        public override string Solve_2()
        {
            for (int i = 0; i < _numbersList.Count; i++)
            {
                for (int j = i; j < _numbersList.Count; j++)
                {
                    for (int k = j; k < _numbersList.Count; k++)
                    {
                        if (_numbersList[i] + _numbersList[j] + _numbersList[k] == 2020)
                        {
                            return (_numbersList[i] * _numbersList[j] * _numbersList[k]).ToString();
                        }
                    }
                }
            }
            throw new SolvingException();
        }
    }
}
