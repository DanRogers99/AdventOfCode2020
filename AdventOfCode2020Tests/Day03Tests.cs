using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Day3Part1()
        {
            Day_03 day03 = new Day_03();
            Assert.Equal("178", day03.Solve_1());
        }

        [Fact]
        public void Day3Part2()
        {
            Day_03 day03 = new Day_03();
            Assert.Equal("3492520200", day03.Solve_2());
        }
    }
}
