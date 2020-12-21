using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_16 : BaseDay
    {
        private TicketInfo ticketInfo;

        public Day_16()
        {
            var file = File.ReadAllText(InputFilePath).Split("\n\n");

            ticketInfo = new TicketInfo
            {
                Category = file[0].Split("\n").ToList(),
                YourTicket = file[1].Replace("your ticket:\n", "").Split(",").Select(x => int.Parse(x)).ToList(),
                NearbyTicket = file[2].Replace("nearby tickets:\n", "")
                                      .Split('\n')
                                      .Select(item => item.Split(",").Select(x => int.Parse(x)).ToList())
                                      .ToList()
            };
        }

        public override string Solve_1()
        {
            List<int> validNumbers = new List<int>();
            List<int> invalidTicketItems = new List<int>();

            foreach (var category in ticketInfo.Category)
            {
                var cat = category.Split(new string[] { ":", " or ", "-" }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(x => int.Parse(x)).ToList();
                validNumbers.AddRange(Enumerable.Range(cat[0], cat[1] + 1 - cat[0]).ToList());
                validNumbers.AddRange(Enumerable.Range(cat[2], cat[3] + 1 - cat[2]).ToList());
            }


            foreach (var nearbyTicket in ticketInfo.NearbyTicket)
            {
                invalidTicketItems.AddRange(nearbyTicket.Where(ticket => !validNumbers.Contains(ticket)));
            }

            foreach (var invalidTicketItem in invalidTicketItems)
            {
                var invalidTicket = ticketInfo.NearbyTicket.Where(x => x.Contains(invalidTicketItem)).FirstOrDefault();
                _ = ticketInfo.NearbyTicket.Remove(invalidTicket);
            }

            return invalidTicketItems.Sum().ToString();
        }

        public override string Solve_2()
        {
            var tempTicketMapping = new Dictionary<string, List<int>>();

            foreach (var item in ticketInfo.Category)
            {
                tempTicketMapping.Add(item.Split(":")[0], new List<int>());
            }

            for (int i = 0; i < ticketInfo.NearbyTicket.FirstOrDefault().Count; i++)
            {
                foreach (var item in ticketInfo.Category)
                {
                    var cat = item.Split(new string[] { ":", " or ", "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (CheckValues(ticketInfo.NearbyTicket.Select(x => x[i]), cat))
                    {
                        tempTicketMapping[cat[0]].Add(i);
                    }
                }
            }

            //Final Mapping
            var ticketMapping = new Dictionary<string, int>();

            var count = tempTicketMapping.Count;

            for (int i = 0; i < count; i++)
            {
                var value = tempTicketMapping.OrderBy(x => x.Value.Count()).FirstOrDefault();

                ticketMapping.Add(value.Key, value.Value.FirstOrDefault());

                tempTicketMapping.Remove(value.Key);

                foreach (var item in tempTicketMapping.Where(x => x.Value.Contains(value.Value.FirstOrDefault())))
                {
                    item.Value.Remove(value.Value.FirstOrDefault());
                }
            }

            long answer = 1;

            foreach (var item in ticketMapping.Where(x => x.Key.StartsWith("departure")))
            {
                answer *= ticketInfo.YourTicket[item.Value];
            }

            return answer.ToString();
        }

        private static bool CheckValues(IEnumerable<int> checkValues, List<string> r)
        {
            List<int> validNumbers = new List<int>();
            validNumbers.AddRange(Enumerable.Range(int.Parse(r[1]), int.Parse(r[2]) + 1 - int.Parse(r[1])).ToList());
            validNumbers.AddRange(Enumerable.Range(int.Parse(r[3]), int.Parse(r[3]) + 1 - int.Parse(r[2])).ToList());


            foreach (var value in checkValues)
            {
                if (!validNumbers.Contains(value))
                {
                    return false;
                }
            }
            return true;
        }

        public class TicketInfo
        {
            public List<string> Category { get; set; }
            public List<int> YourTicket { get; set; }
            public List<List<int>> NearbyTicket { get; set; }
        }
    }
}


