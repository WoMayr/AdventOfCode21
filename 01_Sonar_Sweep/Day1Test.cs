using FluentAssertions;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _01_Sonar_Sweep
{
    public class Day1Test : BaseTest<Day1>
    {
        public Day1Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Day1Test_Part1_Simple()
        {
            subject.Input =
@"199
200
208
210
200
207
240
269
260
263";

            var result = subject.Part1();

            result.Should().Be(7);
        }

        [Fact]
        public void Day1Test_Part2_Simple()
        {
            subject.Input =
@"199
200
208
210
200
207
240
269
260
263";

            var result = subject.Part2();

            result.Should().Be(5);
        }
    }
}
