using AdventOfCode;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day05Tests
    {
        [Fact]
        public void Day5Part1()
        {
            Day_05 day05 = new Day_05();
            Assert.Equal("880", day05.Solve_1());
        }

        [Fact]
        public void Day5Part2()
        {
            Day_05 day05 = new Day_05();
            Assert.Equal("731", day05.Solve_2());
        }
    }
}
