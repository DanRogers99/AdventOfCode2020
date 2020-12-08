using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day04Tests
    {
        [Fact]
        public void Day4Part1()
        {
            Day_04 day04 = new Day_04();
            Assert.Equal("245", day04.Solve_1());
        }

        [Fact]
        public void Day4Part2()
        {
            Day_04 day04 = new Day_04();
            Assert.Equal("133", day04.Solve_2());
        }
    }
}
