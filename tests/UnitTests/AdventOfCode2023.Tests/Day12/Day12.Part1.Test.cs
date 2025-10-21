using static AdventOfCode2023.Core.Day12.Day12;
namespace AdventOfCode2023.Tests.Day12;

public class Day12Part1Test
{
    [TestCase("????##..# 2,1", 1)]
    [TestCase("???.### 1,1,3", 1)]
    [TestCase(".??..??...?##. 1,1,3", 4)]
    [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [TestCase(".??..??...?##. 1,1,3", 4)]
    public void Day12Part1_GetSumOfAllPossibleArrangements_WhenHasOnlyOneConditionRecord_ThenReturnsTheExpectedValue(string text, int expected)
    {
        var result =  new Part1().GetSumOfAllPossibleArrangements(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day12Part1_GetSumOfAllPossibleArrangements_WithSampleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadSampleInput(day: 12, part: 1);
        const long expected = 21;
        var result = new Part1().GetSumOfAllPossibleArrangements(text);
        Assert.That(result, Is.EqualTo(expected));
    }
  
    [Test]
    public void Day12Part1_GetSumOfAllPossibleArrangements_WithPuzzleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadPuzzleInput(day: 12, part: 1);
        const long expected = 8022;
        var result = new Part1().GetSumOfAllPossibleArrangements(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}