using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_14 : BaseDay
    {
        private readonly List<string[]> input;

        public Day_14()
        {
            input = File.ReadAllLines(InputFilePath).Select(x => x.Split('=')).ToList();    
        }

        public override string Solve_1()
        {
            long[] memory = new long[1000000];

            string mask = "";
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][0].StartsWith("mask"))
                {
                    mask = input[i][1].Trim();
                }
                else
                {
                    string binary = Convert.ToString(int.Parse(input[i][1]), 2).PadLeft(36, '0');

                    for (int y = mask.Length - 1; y >= 0; y--)
                    {
                        var bitMask = mask.Substring(y, 1);

                        switch (bitMask)
                        {
                            case "X":
                                break;
                            default:
                                var ca = binary.ToCharArray();
                                ca[y] = bitMask[0];
                                binary = new string(ca);
                                break;
                        }
                    }

                    memory[int.Parse(Regex.Match(input[i][0], @"\d+").Value)] = Convert.ToInt64(binary, 2);
                }
            }
            return memory.Sum().ToString();
        }

        public override string Solve_2()
        {
            var memoryAddressDecoder = new Dictionary<long, long>();
            string mask = "";

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][0].StartsWith("mask"))
                {
                    mask = input[i][1].Trim();
                }
                else
                {
                    var binary = Convert.ToString(int.Parse(Regex.Match(input[i][0], @"\d+").Value), 2).PadLeft(36, '0');
                    binary = Calculate(mask, binary);

                    int count = binary.Count(s => s == 'X');

                    foreach (var item in Enumerable.Range(0, (int)(Math.Pow(2, count))).Select(x => Convert.ToString(x, 2)))
                    {
                        var number = item.PadLeft(count, '0');
                        var ca = binary.ToCharArray();

                        for (int t = 0; t < ca.Length; t++)
                        {
                            if (ca[t] == 'X')
                            {
                                ca[t] = number[0];
                                number = number[1..];
                            }
                        }

                        memoryAddressDecoder[Convert.ToInt64(new string(ca), 2)] = int.Parse(input[i][1]);
                    }
                }
            }

            return  memoryAddressDecoder.Values.Sum().ToString();
        }

        private static string Calculate(string mask, string binary)
        {
            for (int y = mask.Length - 1; y >= 0; y--)
            {
                var bitMask = mask.Substring(y, 1);

                switch (bitMask)
                {
                    case "0":
                        break;
                    default:
                        var ca = binary.ToCharArray();
                        ca[y] = bitMask[0];
                        binary = new string(ca);
                        break;
                }
            }

            return binary;
        }
    }
}


