using static AdventOfCode2023.Core.Day15.Day15;

namespace AdventOfCode2023.Tests.Day15;

public class Day15Part1Test
{
    [Test]
    public void Day15Part1_GetTotalSum_WithSampleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 15, part: 1);
        const int expected = 1320;
        var result = Part1.GetTotalSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day15Part1_GetTotalSum_WithPuzzleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 15, part: 1);
        const int expected = 516469;
        var result = Part1.GetTotalSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}
