using static AdventOfCode2023.Core.Day4.Day4;
namespace AdventOfCode2023.Tests.Day4;

public class Day4Part1Test {

    [Test]
    public void Day4Part1_GetColorfulCardPoints_WhenJustAWinningNumberAndOneCard_ThenReturns1() {
        string rawText = "Card 1: 1 2 3 4 17 | 83 86  6 31 17  9 48 53";
        double expected = 1;
        double result = Part1.GetColorfulCardPoints(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
    [TestCase("Card 2: 53 75 36 17 98 14 | 11 31 55 53 75 36 17 98 14", 32)]
    public void Day4Part1_GetColorfulCardPoints_WhenMultipleAWinningNumbersOnTheSameCard_ThenReturns1(string rawText, double expected) {
        double result = Part1.GetColorfulCardPoints(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day4Part1_GetColorfulCardPoints_WhenSampleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 4, part: 1);
        double expected = 13;
        double result = Part1.GetColorfulCardPoints(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day4Part1_GetColorfulCardPoints_WhenPuzzleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 4, part: 1);
        double expected = 23750;
        double result = Part1.GetColorfulCardPoints(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}