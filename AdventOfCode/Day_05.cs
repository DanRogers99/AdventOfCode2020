using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_05 : BaseDay
    {
        private readonly List<(int Row, int Column, int SeatId)> _tickets;

        public Day_05()
        {
            _tickets = new List<(int Row, int Column, int SeatId)>();

            foreach (var line in File.ReadAllLines(InputFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    int rowLower = 0;
                    int rowHigher = 127;

                    int seatLower = 0;
                    int seatHigher = 7;

                    for (int i = 0; i < 7; i++)
                    {
                        int difference = (int)Math.Ceiling((decimal)(rowHigher - rowLower) / 2);

                        switch (line[i])
                        {
                            case 'F':
                                rowHigher -= difference;
                                break;
                            case 'B':
                                rowLower += difference;
                                break;
                        }
                    }

                    for (int i = 7; i < 10; i++)
                    {
                        int difference = (int)Math.Ceiling((decimal)(seatHigher - seatLower) / 2);

                        switch (line[i])
                        {
                            case 'L':
                                seatHigher -= difference;
                                break;
                            case 'R':
                                seatLower += difference;
                                break;
                        }
                    }

                    _tickets.Add(new (rowLower, seatLower, (rowLower * 8) + seatLower));
                }
            }
        }

        public override string Solve_1()
        {
            return _tickets.OrderBy(x => x.SeatId).LastOrDefault().SeatId.ToString();
        }

        public override string Solve_2()
        {
            var seatIds = _tickets.OrderBy(x => x.SeatId).Select(x => x.SeatId);
            return Enumerable.Range(seatIds.First(), seatIds.Last() - seatIds.First() + 1).Except(seatIds).Select(x => x.ToString()).FirstOrDefault();
        }

    }
}
