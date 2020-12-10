using AoCHelper;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_10 : BaseDay
    {
        private readonly List<int> _input;
        private readonly Dictionary<int, long> _counts = new Dictionary<int, long>();
        public Day_10()
        {
            _input = File.ReadAllLines(InputFilePath).Select(line => int.Parse(line)).OrderBy(x => x).ToList();
        }

        public override string Solve_1()
        {
            List<int> adapters = new List<int> { 0 };

            while (true)
            {
                int joltage = _input.Where(x => x <= adapters.LastOrDefault() + 3 && x > adapters.LastOrDefault()).FirstOrDefault();

                if (joltage != 0)
                {
                    adapters.Add(joltage);
                }
                else
                {
                    break;
                }
            }

            int dif1 = 0;
            int dif3 = 1;

            for (int i = 1; i < adapters.Count; i++)
            {
                switch (adapters[i] - adapters[i - 1])
                {
                    case 3:
                        dif3++;
                        break;
                    case 1:
                        dif1++;
                        break;
                }
            }

            return (dif1 * dif3).ToString();

        }

        public override string Solve_2()
        {
            var joltages = _input.OrderBy(x => x).ToList();
            joltages.Insert(0, 0);

            return CountArrangements(0, joltages).ToString();
        }

        private long CountArrangements(int startIdx, List<int> joltages)
        {
            if (!_counts.ContainsKey(startIdx))
            {
                if (startIdx == joltages.Count - 1)
                {
                    return 1;
                }

                long result = 0;

                for (var i = startIdx + 1; i < joltages.Count && joltages[i] <= joltages[startIdx] + 3; i++)
                {
                    result += CountArrangements(i, joltages);
                }

                _counts.Add(startIdx, result);
                return result;
            }
            return _counts[startIdx];
        }

    }

}


