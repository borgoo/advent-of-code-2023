using static AdventOfCode2023.Core.Day9.Day9;

namespace AdventOfCode2023.Tests.Day9;

public class Day9Part1Test {


    [TestCase("3703 32957 91379 178969", 295727)]
    [TestCase("3802 33732 93480 183046", 302430)]
    public void Day9Part1_GetSumOfExtrapolatedValues_WithDay21Part2InputData_ReturnsExpectedValue(string text, long expected)
    {
        var result = Part1.GetSumOfExtrapolatedValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day9Part1_GetSumOfExtrapolatedValues_WithSampleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadSampleInput(day: 9, part: 1);
        const long expected = 114;

        var result = Part1.GetSumOfExtrapolatedValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day9Part1_GetSumOfExtrapolatedValues_WithPuzzleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadPuzzleInput(day: 9, part: 1);
        const long expected = 2075724761;

        var result = Part1.GetSumOfExtrapolatedValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

}
