using AdventOfCode;
using System;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Day2Part1()
        {
            Day_02 day02 = new Day_02();
            Assert.Equal("564", day02.Solve_1());
        }

        [Fact]
        public void Day2Part2()
        {
            Day_02 day02 = new Day_02();
            Assert.Equal("325", day02.Solve_2());
        }
    }
}
