using static AdventOfCode2023.Core.Day14.Day14;
namespace AdventOfCode2023.Tests.Day14;

public class Day14Part1Test
{
    [Test]
    public void Day14Part1_GetTotalLoad_WhenSampleInput_ThenReturnsExpectedValue() {
        string text = TestDataHelper.LoadSampleInput(day: 14, part: 1);
        const int expected = 136;
        var result = Part1.GetTotalLoad(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day14Part1_GetTotalLoad_WhenPuzzleInput_ThenReturnsExpectedValue() {
        string text = TestDataHelper.LoadPuzzleInput(day: 14, part: 1);
        const int expected = 107053;
        var result = Part1.GetTotalLoad(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}