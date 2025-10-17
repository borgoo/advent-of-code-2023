using static AdventOfCode2023.Core.Day9.Day9;

namespace AdventOfCode2023.Tests.Day9;

public class Day9Part2Test {

    [TestCase("0 3 6 9 12 15", -3)]
    [TestCase("1 3 6 10 15 21", 0)]
    [TestCase("10 13 16 21 30 45", 5)]
    public void Day9Part2_GetSumOfExtrapolatedPreviousValues_WhenOnlyOneRecordIsPresent_ThenReturnsExpectedValue(string text, long expected) {

        var result = Part2.GetSumOfExtrapolatedPreviousValues(text);
        Assert.That(result, Is.EqualTo(expected));

    }

    
    [Test]
    public void Day9Part2_GetSumOfExtrapolatedPreviousValues_WithSampleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadSampleInput(day: 9, part: 1);
        const long expected = 2;

        var result = Part2.GetSumOfExtrapolatedPreviousValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day9Part2_GetSumOfExtrapolatedPreviousValues_WithPuzzleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadPuzzleInput(day: 9, part: 1);
        const long wrongAnswer = 10;
        const long wrongAnswer2 = 52;
        const long expected = 1072;

        var result = Part2.GetSumOfExtrapolatedPreviousValues(text);

        Assert.That(result, Is.Not.EqualTo(wrongAnswer));
        Assert.That(result, Is.Not.EqualTo(wrongAnswer2));
        Assert.That(result, Is.EqualTo(expected));
    }

}
