using AoCHelper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_13 : BaseDay
    {
        private readonly long earliestTime;
        private readonly List<string> departureTimes;
        private readonly List<KeyValuePair<int, long>> depatureTimeWait;

        public Day_13()
        {
            string[] input = File.ReadAllLines(InputFilePath);

            earliestTime = int.Parse(input[0]);
            departureTimes = input[1].Split(',').ToList();
            depatureTimeWait = new List<KeyValuePair<int, long>>();

            foreach (var departureTime in departureTimes.Where(x => x != "x").Select(x => int.Parse(x)))
            {
                decimal time = earliestTime;
                decimal factor = (time / departureTime);

                while ((int)factor != factor)
                {
                    time++;
                    factor = (time / departureTime);
                }
                depatureTimeWait.Add(new KeyValuePair<int, long>(departureTime, (long)(time - earliestTime)));
            }

        }

        public override string Solve_1()
        {
            var smallestValue = depatureTimeWait.Select(p => (p.Value, p)).Min();
            return (smallestValue.p.Key * smallestValue.p.Value).ToString();
        }

        public override string Solve_2()
        {
            var busesSequance = new List<KeyValuePair<long, long>>();

            for (var i = 0; i < departureTimes.Count; i++)
            {
                if (departureTimes[i] != "x")
                {
                    busesSequance.Add(new KeyValuePair<long, long>(i, int.Parse(departureTimes[i])));
                }
            }

            return ChineseRemainderTheorem.Solve(busesSequance.Select(x => x.Value).ToArray(), busesSequance.Select(x => x.Value - x.Key).ToArray()).ToString();
        }
    }

    //Modified from https://rosettacode.org/wiki/Chinese_remainder_theorem#C.23
    public static class ChineseRemainderTheorem
    {
        public static long Solve(long[] n, long[] a)
        {
            var prod = n.Aggregate(1L, (i, j) => i * j);
            long p;
            long sm = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        private static int ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (int x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }

}


