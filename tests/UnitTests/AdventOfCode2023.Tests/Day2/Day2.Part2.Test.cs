using static AdventOfCode2023.Core.Day2.Day2;
namespace AdventOfCode2023.Tests.Day2;


public class Day2Part2Test {

    [Test]
    public void Day2Part2_CheckIfPossible_WhenJustOneGameIsPLayed_ThenReturns48() {

        string rawText = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        const int expected = 48;
        int result = Part2.CheckIfPossible(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day2Part2_CheckIfPossible_WhenMultipleGamesArePlayed_ThenReturns60() {

        string rawText = $"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green{Environment.NewLine}"+
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
        const int expected = 48 + 12;
        int result = Part2.CheckIfPossible(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }


    [Test]
    public void Day2Part2_CheckIfPossible_WithSampleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 2, part: 1);
        const int expected = 2286;

        int result = Part2.CheckIfPossible(rawText);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day2Part2_CheckIfPossible_WithPuzzleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 2, part: 1);
        const int expected = 54911;

        int result = Part2.CheckIfPossible(rawText);

        Assert.That(result, Is.EqualTo(expected));
    }
}
