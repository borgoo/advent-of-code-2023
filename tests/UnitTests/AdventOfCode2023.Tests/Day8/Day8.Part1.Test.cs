using static AdventOfCode2023.Core.Day8.Day8;

namespace AdventOfCode2023.Tests.Day8;

public class Day8Part1Test {

    [Test]
    public void Day8Part1_GetNumOfSteps_WhenMultipleIterationsOnInputAreRequired_ThenReturns6() {
        string text = @"LLR

                        AAA = (BBB, BBB)
                        BBB = (AAA, ZZZ)
                        ZZZ = (ZZZ, ZZZ)";
        const int expected = 6;

        var result = Part1.GetNumOfSteps(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day8Part1_GetNumOfSteps_WithSampleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadSampleInput(day: 8, part: 1);
        const int expected = 2;

        var result = Part1.GetNumOfSteps(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day8Part1_GetNumOfSteps_WithPuzzleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadPuzzleInput(day: 8, part: 1);
        const int expected = 12643;

        var result = Part1.GetNumOfSteps(text);

        Assert.That(result, Is.EqualTo(expected));
    }

}
