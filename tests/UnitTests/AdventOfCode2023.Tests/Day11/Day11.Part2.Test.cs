using static AdventOfCode2023.Core.Day11.Day11;
namespace AdventOfCode2023.Tests.Day11;

public class Day11Part2Test
{
    [Test]
    public void Day11Part2_GetSumOfMinPathsBetweenGalaxies_WithSampleInput_WhenExpansionFactorIs10_ThenReturns1030()
    {
        string text = TestDataHelper.LoadSampleInput(day: 11, part: 1);
        const int expansionFactor = 10;
        const long expected = 1030;
        Part2 part2 = new(expansionFactor);
        var result = part2.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    public void Day11Part2_GetSumOfMinPathsBetweenGalaxies_WithPuzzleInput_WhenExpansionFactorIs100_ThenReturns8410()
    {
        string text = TestDataHelper.LoadSampleInput(day: 11, part: 1);
        const int expansionFactor = 100;
        const long expected = 8410;
        Part2 part2 = new(expansionFactor);
        var result = part2.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day11Part2_GetSumOfMinPathsBetweenGalaxies_WithSampleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadSampleInput(day: 11, part: 1);
        const long expected = 82000210;
        Part2 part2 = new();
        var result = part2.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    public void Day11Part2_GetSumOfMinPathsBetweenGalaxies_WithPuzzleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadPuzzleInput(day: 11, part: 1);
        const long expected = 746962097860;
        Part2 part2 = new();
        var result = part2.GetSumOfMinPathsBetweenGalaxies(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}