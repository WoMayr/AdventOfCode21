using _03_Binary_Diagnostic;
using Microsoft.Extensions.Logging;
using Utils;

BaseProgram.BaseMain<Day3, Program>((day, _, logger) =>
{
    day.Input = File.ReadAllText("input.txt");

    var powerConsumption = day.GetPowerConsumption();

    logger.LogInformation("Power Consumption is {PowerConsumption}", powerConsumption);

    var lifeSupport = day.GetLifeSupportRating();
    logger.LogInformation("Life Support Rating is {LifeSupportRating}", lifeSupport);
});