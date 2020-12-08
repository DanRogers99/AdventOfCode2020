using AdventOfCode;
using AoCHelper;
using System;
using Xunit;

namespace AdventOfCode2020Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Day1Part1()
        {
            Day_01 day01 = new Day_01();
            Assert.Equal("494475", day01.Solve_1());
        }

        [Fact]
        public void Day1Part2()
        {
            Day_01 day01 = new Day_01();
            Assert.Equal("267520550", day01.Solve_2());
        }
    }
}
