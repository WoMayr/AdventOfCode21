using _01_Sonar_Sweep;
using Microsoft.Extensions.Logging;
using Utils;

BaseProgram.BaseMain<Day1, Program>((day, _, logger) =>
{
    day.Input = File.ReadAllText("input.txt");
    var increases = day.Part1();

    logger.LogInformation("It increases {Increases} times", increases);


    var increases2 = day.Part2();

    logger.LogInformation("Sliding Window increases {Increases} times", increases2);
});