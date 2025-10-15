using static AdventOfCode2023.Core.Day6.Day6;
namespace AdventOfCode2023.Tests.Day6;

public class Day6Part1Test
{
    [Test]
    public void Day6Part1_CalculateMarginError_WhenThereIsOneOnlyRace_ShouldReturn4(){
        string rawText = $"Time:      7{Environment.NewLine}Distance:  9";
        long expected = 4;
        long result = Part1.CalculateMarginError(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day6Part1_CalculateMarginError_WhenThereAreTwoRaces_ShouldReturn32(){
        string rawText = $"Time:      7  15{Environment.NewLine}Distance:  9  40";
        long expected = 32;
        long result = Part1.CalculateMarginError(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day6Part1_CalculateMarginError_WhenOneRaceIsUnbeatable_ShouldReturn0(){
        string rawText = $"Time:      7  2  30{Environment.NewLine}Distance:  9  40  200";
        long expected = 0;
        long result = Part1.CalculateMarginError(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day6Part1_CalculateMarginError_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 6, part: 1);
        long expected = 288;
        long result = Part1.CalculateMarginError(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day6Part1_CalculateMarginError_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 6, part: 1);
        long expected = 252000;
        long result = Part1.CalculateMarginError(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}