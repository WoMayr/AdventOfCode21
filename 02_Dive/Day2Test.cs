using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _02_Dive
{
    public class Day2Test : BaseTest<Day2>
    {
        public Day2Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Day2_Part1_Simple()
        {
            subject.Input =
@"forward 5
down 5
forward 8
up 3
down 8
forward 2";

            subject.Part1();

            (subject.Depth * subject.Horzontal).Should().Be(150);
        }

        [Fact]
        public void Day2_Part2_Simple()
        {
            subject.Input =
@"forward 5
down 5
forward 8
up 3
down 8
forward 2";

            subject.Part2();

            (subject.Depth * subject.Horzontal).Should().Be(900);
        }
    }
}
