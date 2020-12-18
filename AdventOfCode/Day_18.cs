using AoCHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_18 : BaseDay
    {
        readonly List<string> _file;
        public Day_18()
        {
            _file = File.ReadAllLines(InputFilePath).ToList();
        }

        public override string Solve_1()
        {
            long sum = 0;
            foreach (var item in _file)
            {
                string total = new string(SolveBracket(new String(item.Replace(" ", "")).ToCharList(), false).ToArray());
                sum += long.Parse(SolveLeftToRight(total, false));
            }
            return sum.ToString();
        }

        public override string Solve_2()
        {
            long sum = 0;
            foreach (var item in _file)
            {
                string total = new string(SolveBracket(new String(item.Replace(" ", "")).ToCharList(), true).ToArray());
                sum += long.Parse(SolveLeftToRight(total, true));
            }
            return sum.ToString();
        }

        private static string SolveLeftToRight(string total, bool additionHigherPrecedenceLevel)
        {
            var validChar = new char[] { '+', '-', '/', '*' };
            var charArray = total.SplitAndKeep(validChar).ToList();

            while (charArray.Count > 1)
            {
                int characterIndex = 1;
                char arithCharacter = charArray[1][0];

                List<CharIndex> priority = new List<CharIndex>();

                if (additionHigherPrecedenceLevel)
                {
                    priority.AddRange(charArray.Select((b, i) => b.Equals("+") ? i : -1).Where(i => i != -1).Select(x => new CharIndex { Character = '+', Index = x }));
                    priority.AddRange(charArray.Select((b, i) => b.Equals("-") ? i : -1).Where(i => i != -1).Select(x => new CharIndex { Character = '-', Index = x }));

                    if (priority.Count != 0)
                    {
                        characterIndex = priority.FirstOrDefault().Index;
                        arithCharacter = priority.FirstOrDefault().Character;
                    }

                }

                var calculation = ExtentionMethods.Evaluate($"{charArray[characterIndex - 1]} {arithCharacter} {charArray[characterIndex + 1]}");

                for (int i = 0; i < 3; i++)
                {
                    charArray.RemoveAt(characterIndex - 1);
                }

                charArray.Insert(characterIndex - 1, calculation.ToString());
            }
            return charArray[0];
        }

        private List<char> SolveBracket(List<char> bracket, bool additionHigherPrecedenceLevel)
        {
            List<CharIndex> brackets = new List<CharIndex>();
            brackets.AddRange(bracket.Select((b, i) => b.Equals('(') ? i : -1).Where(i => i != -1).Select(x => new CharIndex { Character = '(', Index = x }));
            brackets.AddRange(bracket.Select((b, i) => b.Equals(')') ? i : -1).Where(i => i != -1).Select(x => new CharIndex { Character = ')', Index = x }));
            brackets = brackets.OrderBy(x => x.Index).ToList();

            for (int i = 0; i < brackets.Count; i++)
            {
                if (brackets[i].Character == '(' && brackets[i + 1].Character == ')')
                {
                    var expression = new string(bracket.Skip(brackets[i].Index + 1).Take(brackets[i + 1].Index - brackets[i].Index - 1).ToArray());
                    bracket.RemoveRange(brackets[i].Index, brackets[i + 1].Index - brackets[i].Index + 1);
                    bracket.InsertRange(brackets[i].Index, SolveLeftToRight(expression, additionHigherPrecedenceLevel).ToString().ToCharArray());
                    break;
                }
            }

            if (bracket.Contains('('))
            {
                SolveBracket(bracket, additionHigherPrecedenceLevel);
            }

            return bracket;
        }

        public record CharIndex
        {
            public char Character { get; set; }
            public int Index { get; set; }
        }
    }
}


