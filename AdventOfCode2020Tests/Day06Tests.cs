using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Day6Part1()
        {
            Day_06 day06 = new Day_06();
            Assert.Equal("6748", day06.Solve_1());
        }

        [Fact]
        public void Day6Part2()
        {
            Day_06 day06 = new Day_06();
            Assert.Equal("3445", day06.Solve_2());
        }
    }
}
