using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _05_Hydrothermal_Venture
{
    public class Day5Test : BaseTest<Day5>
    {
        private readonly ILogger<Day5Test> logger;

        public Day5Test(ITestOutputHelper output)
            : base(output)
        {
            this.logger = services.GetRequiredService<ILogger<Day5Test>>();
        }

        private string GridToString(int[,] grid, int outWidth)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            var sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var value = grid[x, y];
                    sb.Append(string.Format($"{{0,-{outWidth}}}", value > 0 ? value.ToString() : "."));
                }

                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        [Fact]
        public void Part1()
        {
            subject.Input =
@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

            var grid = subject.Read1();
            var result = subject.Overlapping(grid);

            var outWidth = (int)Math.Ceiling(Math.Log10(Math.Max(grid.GetLength(0), grid.GetLength(1))));

            var gridString = GridToString(grid, outWidth);
            logger.LogInformation(gridString);

            gridString.Should().Be(
@".......1..
..1....1..
..1....1..
.......1..
.112111211
..........
..........
..........
..........
222111...."
);

            result.Should().Be(5);
        }

        [Fact]
        public void Part2()
        {
            subject.Input =
@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

            var grid = subject.Read2();
            var result = subject.Overlapping(grid);

            var outWidth = (int)Math.Ceiling(Math.Log10(Math.Max(grid.GetLength(0), grid.GetLength(1))));

            var gridString = GridToString(grid, outWidth);
            logger.LogInformation(gridString);

            gridString.Should().Be(
@"1.1....11.
.111...2..
..2.1.111.
...1.2.2..
.112313211
...1.2....
..1...1...
.1.....1..
1.......1.
222111...."
);

            result.Should().Be(12);
        }
    }
}
