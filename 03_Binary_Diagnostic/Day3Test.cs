using FluentAssertions;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _03_Binary_Diagnostic
{
    public class Day3Test : BaseTest<Day3>
    {
        public Day3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Simple()
        {
            subject.Input =
@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

            var result = subject.GetPowerConsumption();

            result.Should().Be(198);
        }

        [Fact]
        public void Part2_Simple()
        {
            subject.Input =
@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

            var result = subject.GetLifeSupportRating();

            result.Should().Be(230);
        }
    }
}
