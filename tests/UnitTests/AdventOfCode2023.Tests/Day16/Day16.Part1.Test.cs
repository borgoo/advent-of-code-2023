using static AdventOfCode2023.Core.Day16.Day16;

namespace AdventOfCode2023.Tests.Day16;

public class Day16Part1Test
{
    [Test]
    public void Day16Part1_GetNumberOfEnergizedTiles_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 16, part: 1);
        const int expected = 46;
        int result = Part1.GetNumberOfEnergizedTiles(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Day16Part1_GetNumberOfEnergizedTiles_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 16, part: 1);
        const int expected = 8112;
        int result = Part1.GetNumberOfEnergizedTiles(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}