using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05_Hydrothermal_Venture
{
    public record HydrothermalLine(int x1, int y1, int x2, int y2)
    {
        private static readonly Regex lineRegex = new(@"^(\d+),(\d+) -> (\d+),(\d+)$");

        public static HydrothermalLine FromString(string str)
        {
            Match match = lineRegex.Match(str.Trim());

            return new(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value),
                int.Parse(match.Groups[4].Value));
        }
    }
}
