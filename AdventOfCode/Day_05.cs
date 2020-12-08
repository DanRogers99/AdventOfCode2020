using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_05 : BaseDay
    {
        private readonly List<Seat> _tickets;

        public Day_05()
        {
            _tickets = new List<Seat>();

            foreach (var line in File.ReadAllLines(InputFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                { 
                    var row = Convert.ToInt32(line.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                    var seat = Convert.ToInt32(line.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2);

                    _tickets.Add(new Seat { Column = seat, Row = row });
                }
            }
        }

        public override string Solve_1() => _tickets.OrderBy(x => x.SeatId).LastOrDefault().SeatId.ToString();

        public override string Solve_2()
        {
            var seatIds = _tickets.OrderBy(x => x.SeatId).Select(x => x.SeatId);
            return Enumerable.Range(seatIds.First(), seatIds.Last() - seatIds.First() + 1).Except(seatIds).Select(x => x.ToString()).FirstOrDefault();
        }
    }

    record Seat
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public int SeatId => (Row * 8) + Column;
    }
}
