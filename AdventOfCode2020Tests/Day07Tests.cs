using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Day7Part1()
        {
            Day_07 day07 = new Day_07();
            Assert.Equal("302", day07.Solve_1());
        }

        [Fact]
        public void Day7Part2()
        {
            Day_07 day07 = new Day_07();
            Assert.Equal("4165", day07.Solve_2());
        }
    }
}
