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
                    var row = Convert.ToInt32(line.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                    var seat = Convert.ToInt32(line.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);
                    _tickets.Add(new (row, seat, (row * 8) + seat));
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
