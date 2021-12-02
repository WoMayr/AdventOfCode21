using Microsoft.Extensions.Logging;
using Utils;

namespace _02_Dive
{
    public class Day2 : BaseDay
    {
        private readonly ILogger<Day2> logger;

        public int Depth { get; private set; } = 0;
        public int Horzontal { get; private set; } = 0;
        public int Aim { get; private set; } = 0;

        public Day2(ILogger<Day2> logger)
        {
            this.logger = logger;
        }

        public void Reset()
        {
            Depth = 0;
            Horzontal = 0;
            Aim = 0;
        }

        public void Part1()
        {
            var commands = Input.Split('\n');

            var lineNo = 1;
            foreach (var command in commands)
            {
                try
                {
                    var parts = command.Split(' ');
                    var what = parts[0];
                    var where = int.Parse(parts[1]);

                    switch (what)
                    {
                        case "up": Depth -= where; break;
                        case "down": Depth += where; break;
                        case "forward": Horzontal += where; break;
                        default:
                            logger.LogError("Unknown command: {Command}", what);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Error parsing line {LineNo}: {Line}", lineNo, command);
                }
                lineNo++;
            }
        }

        public void Part2()
        {
            var commands = Input.Split('\n');

            var lineNo = 1;
            foreach (var command in commands)
            {
                try
                {
                    var parts = command.Split(' ');
                    var what = parts[0];
                    var where = int.Parse(parts[1]);

                    switch (what)
                    {
                        case "up":
                            Aim -= where;
                            break;
                        case "down":
                            Aim += where;
                            break;
                        case "forward":
                            Horzontal += where;
                            Depth += where * Aim;
                            break;
                        default:
                            logger.LogError("Unknown command: {Command}", what);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Error parsing line {LineNo}: {Line}", lineNo, command);
                }
                lineNo++;
            }
        }
    }
}