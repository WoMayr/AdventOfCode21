using _04_Giant_Squid;
using Microsoft.Extensions.Logging;
using Utils;

BaseProgram.BaseMain<Day4, Program>((day, _, logger) =>
{
    day.Input = File.ReadAllText("input.txt");

    var winningScore = day.GetWinningScore();

    logger.LogInformation("Winning Score is {WinningScore}", winningScore);

    var lastWinningScore = day.GetLastWinningScore();

    logger.LogInformation("Last Winning Score is {LastWinningScore}", lastWinningScore);
});