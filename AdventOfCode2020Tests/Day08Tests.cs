using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Day8Part1()
        {
            Day_08 day08 = new Day_08();
            Assert.Equal("1832", day08.Solve_1());
        }

        [Fact]
        public void Day8Part2()
        {
            Day_08 day08 = new Day_08();
            Assert.Equal("662", day08.Solve_2());
        }
    }
}
