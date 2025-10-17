using static AdventOfCode2023.Core.Day9.Day9;

namespace AdventOfCode2023.Tests.Day9;

public class Day9Part1Test {

    
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
