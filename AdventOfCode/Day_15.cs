using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_15 : BaseDay
    {
        private readonly List<int> input;

        public Day_15()
        {
            input = File.ReadAllText(InputFilePath).Split(',').Select(x => int.Parse(x)).ToList();
        }

        public override string Solve_1() => Solve(2020);

        public override string Solve_2() => Solve(30000000);

        private string Solve(int numberSpoken)
        {
            var answers = new Dictionary<int, Answer>();

            for (int i = 0; i < input.Count; i++)
            {
                answers.Add(input[i], new Answer { P1 = i + 1 });
            }

            var previous = answers.OrderByDescending(x => x.Value.P1).Select(x => x.Key).FirstOrDefault();

            for (int i = 0; i < (numberSpoken - input.Count); i++)
            {
                var currentIndex = input.Count + i + 1;

                if (answers[previous].P2.HasValue)
                {
                    var calc = answers[previous].P1 - answers[previous].P2.Value;
                    AddNewValue(answers, currentIndex, calc);
                    previous = calc;
                }
                else
                {
                    AddNewValue(answers, currentIndex, 0);
                    previous = 0;
                }
            }
            return answers.OrderByDescending(x => x.Value.P1).Select(x => x.Key).FirstOrDefault().ToString();
        }

        private static void AddNewValue(Dictionary<int, Answer> answers, int currentIndex, int value)
        {
            if (answers.ContainsKey(value))
            {
                answers[value].P2 = answers[value].P1;
                answers[value].P1 = currentIndex;
            }
            else
            {
                answers.Add(value, new Answer
                {
                    P1 = currentIndex,
                    P2 = null
                });
            }
        }
    }

    public class Answer
    {
        public int P1 { get; set; }
        public int? P2 { get; set; }
    }
}


