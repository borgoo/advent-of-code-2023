using static AdventOfCode2023.Core.Day12.Day12;
namespace AdventOfCode2023.Tests.Day12;

public class Day12Part2Test
{

    [Test]
    public void Day12Part2_GetSumOfAllPossibleArrangements_WithSampleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadSampleInput(day: 12, part: 1);
        const long expected = 525152;
        var result = new Part2().GetSumOfAllPossibleArrangements(text);
        Assert.That(result, Is.EqualTo(expected));
    }
  
    [Test]
    public void Day12Part2_GetSumOfAllPossibleArrangements_WithPuzzleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadPuzzleInput(day: 12, part: 1);
        const long expected = 4968620679637;
        var result = new Part2().GetSumOfAllPossibleArrangements(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}