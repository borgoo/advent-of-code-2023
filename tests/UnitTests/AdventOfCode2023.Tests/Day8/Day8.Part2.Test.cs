using static AdventOfCode2023.Core.Day8.Day8; 
namespace AdventOfCode2023.Tests.Day8;

public class Day8Part2Test {

    [Test]
    public void Day8Part2_GetNumOfSteps_WhenSampleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 8, part: 2);
        long expected = 6;
        long result = Part2.GetNumOfSteps(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day8Part2_GetNumOfSteps_WhenPuzzleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 8, part: 1);
        long expected = 13133452426987; 
        long result = Part2.GetNumOfSteps(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}