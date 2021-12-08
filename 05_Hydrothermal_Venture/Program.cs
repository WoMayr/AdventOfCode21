using _05_Hydrothermal_Venture;
using Microsoft.Extensions.Logging;
using Utils;

BaseProgram.BaseMain<Day5, Program>((day, _, logger) =>
{
    day.Input = File.ReadAllText("input.txt");
    var grid1 = day.Read1();
    var result1 = day.Overlapping(grid1);

    logger.LogInformation("Overlapping at {Points} points", result1);

    var grid2 = day.Read2();
    var result2 = day.Overlapping(grid2);

    logger.LogInformation("Overlapping at {Points} points", result2);
});