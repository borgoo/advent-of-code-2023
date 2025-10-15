using static AdventOfCode2023.Core.Day6.Day6;

namespace AdventOfCode2023.Tests.Day6;

public class Day6Part2Test
{
    [Test]
    public void Day6Part2_GetNumOfWinningOutcomes_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 6, part: 1);
        long expected = 71503;
        long result = Part2.GetNumOfWinningOutcomes(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day6Part2_GetNumOfWinningOutcomes_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 6, part: 1);
        long expected = 36992486;
        long result = Part2.GetNumOfWinningOutcomes(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}