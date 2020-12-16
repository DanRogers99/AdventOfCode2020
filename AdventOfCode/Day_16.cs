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
                YourTicket = file[1].Replace("your ticket:\n", "").Split(",").ToList(),
                NearbyTicket = file[2].Replace("nearby tickets:\n", "")
                                      .Split('\n')
                                      .Select(item => item.Split(",").Select(x => int.Parse(x)).ToList())
                                      .ToList()
            };
        }

        public override string Solve_1()
        {
            List<int> validNumbers = new List<int>();

            foreach (var category in ticketInfo.Category)
            {
                foreach (var range in category.Split(":")[1].Split("or").Select(x => x.Split("-")).ToList())
                {
                    validNumbers.AddRange(Enumerable.Range(int.Parse(range[0]), int.Parse(range[1]) + 1 - int.Parse(range[0])).ToList());
                }
            }

            List<int> invalidTicketItems = new List<int>();

            foreach (var nearbyTicket in ticketInfo.NearbyTicket)
            {
                foreach (var ticket in nearbyTicket)
                {
                    if (!validNumbers.Contains(ticket))
                    {
                        invalidTicketItems.Add(ticket);
                    }
                }
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
                    var categoryName = item.Split(":")[0];
                    var range = item.Split(":")[1].Split("or").Select(x => x.Split("-")).ToList();

                    if (CheckValues(ticketInfo.NearbyTicket.Select(x => x[i]), range))
                    {
                        tempTicketMapping[categoryName].Add(i);
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
                answer *= int.Parse(ticketInfo.YourTicket[item.Value]);
            }

            return answer.ToString();
        }

        private static bool CheckValues(IEnumerable<int> checkValues, List<string[]> ranges)
        {
            List<int> validNumbers = new List<int>();

            foreach (var range in ranges)
            {
                validNumbers.AddRange(Enumerable.Range(int.Parse(range[0]), int.Parse(range[1]) + 1 - int.Parse(range[0])).ToList());
            }

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
            public List<string> YourTicket { get; set; }
            public List<List<int>> NearbyTicket { get; set; }
        }
    }
}


