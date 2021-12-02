using _02_Dive;
using Microsoft.Extensions.Logging;
using Utils;

BaseProgram.BaseMain<Day2, Program>((day, _, logger) =>
{
    day.Input = File.ReadAllText("input.txt");

    day.Part1();

    logger.LogInformation("Depth: {Depth}; Horizontal: {Horizontal}; D*H = {Product}", day.Depth, day.Horzontal, day.Depth * day.Horzontal);
    day.Reset();

    day.Part2();
    logger.LogInformation("Depth: {Depth}; Horizontal: {Horizontal}; D*H = {Product}", day.Depth, day.Horzontal, day.Depth * day.Horzontal);
});