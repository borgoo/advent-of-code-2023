using static AdventOfCode2023.Core.Day11.Day11;
namespace AdventOfCode2023.Tests.Day11;

public class Day11Part1Test
{

    [Test]
    public void Day11Part1_GetSumOfMinPathsBetweenGalaxies_WithSampleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadSampleInput(day: 11, part: 1);
        const long expected = 374;
        Part1 part1 = new();
        var result = part1.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    public void Day11Part1_GetSumOfMinPathsBetweenGalaxies_WithPuzzleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadPuzzleInput(day: 11, part: 1);
        const long expected = 9591768;
        Part1 part1 = new();
        var result = part1.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}