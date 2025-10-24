using static AdventOfCode2023.Core.Day16.Day16;

namespace AdventOfCode2023.Tests.Day16;

public class Day16Part2Test
{
    [Test]
    public void Day16Part2_LaunchTheBeam_WhenStartedFrom4ThTileFromTop_ThenReturns51()
    {

        const int expected = 51;

        string rawText = TestDataHelper.LoadSampleInput(day: 16, part: 1);
        string[] lines = rawText.Split(Environment.NewLine);
        int rows = lines.Length;
        int cols = lines[0].Length;
        (int x, int y) start = (0, 3);
        char startDirection = 'v';
        Dictionary<Part2.Node, List<Part2.Node>> cache = [];

        int result = Part2.LaunchTheBeam( cache, lines, rows, cols, start, startDirection);

        Assert.That(result, Is.EqualTo(expected));
    }

    
    [Test]
    public void Day16Part2_GetBestNumberOfEnergizedTiles_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 16, part: 1);
        const int expected = 51;
        int result = Part2.GetBestNumberOfEnergizedTiles(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day16Part2_GetBestNumberOfEnergizedTiles_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 16, part: 1);
        const int expected = 8314;
        int result = Part2.GetBestNumberOfEnergizedTiles(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}