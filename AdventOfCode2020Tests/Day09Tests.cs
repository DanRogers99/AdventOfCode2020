using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day09Tests
    {
        [Fact]
        public void Day9Part1()
        {
            Day_09 day09 = new Day_09();
            Assert.Equal("556543474", day09.Solve_1());
        }

        [Fact]
        public void Day9Part2()
        {
            Day_09 day09 = new Day_09();
            Assert.Equal("76096372", day09.Solve_2());
        }
    }
}
