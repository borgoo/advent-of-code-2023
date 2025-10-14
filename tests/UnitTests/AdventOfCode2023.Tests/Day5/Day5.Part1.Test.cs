using static AdventOfCode2023.Core.Day5.Day5;
namespace AdventOfCode2023.Tests.Day5;

public class Day5Part1Test
{
    [Test]
    public void Day5Part1_GetLowestLocationNumber_WithSampleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 5, part: 1);
        const int expected = 35;
        var day5 = new Part1();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part1_GetLowestLocationNumber_WithPuzzleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 5, part: 1);
        const int expected = 318728750;
        var day5 = new Part1();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}