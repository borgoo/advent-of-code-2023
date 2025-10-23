using static AdventOfCode2023.Core.Day15.Day15;

namespace AdventOfCode2023.Tests.Day15;

public class Day15Part2Test
{
    [Test]
    public void Day15Part2_GetTotalFocusingPower_WithSampleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 15, part: 1);
        const int expected = 145;
        var result = Part2.GetTotalFocusingPower(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day15Part2_GetTotalFocusingPower_WithPuzzleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 15, part: 1);
        const int expected = 221627;
        var result = Part2.GetTotalFocusingPower(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}
