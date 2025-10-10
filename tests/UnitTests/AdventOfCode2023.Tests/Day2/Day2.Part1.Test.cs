using static AdventOfCode2023.Core.Day2.Day2;
namespace AdventOfCode2023.Tests.Day2;


public class Day2Part1Test {

    [Test]
    public void Day2Part1_CheckIfPossible_WhenTheAvailableCubesAreLessThanTheRequiredCubes_ThenReturns0() {

        string rawText = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        ExtractionData maxAvailableCubes = new(1, 1, 1);
        const int expected = 0;
        int result = Part1.CheckIfPossible(rawText, maxAvailableCubes);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day2Part1_CheckIfPossible_WhenInputContainsLongNumbersAndTheAvailableCubesAreLessThanTheRequiredCubes_ThenReturns0() {

        string rawText = "Game 1: 300 blue, 4 red; 10 red, 20000 green, 67 blue; 21 green";
        ExtractionData maxAvailableCubes = new(1, 1, 1);
        const int expected = 0;
        int result = Part1.CheckIfPossible(rawText, maxAvailableCubes);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day2Part1_CheckIfPossible_WhenTheAvailableCubesAreMoreThanTheRequiredCubes_ThenReturns1() {

        string rawText = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        ExtractionData maxAvailableCubes = new(12, 13, 14);
        const int expected = 1;
        int result = Part1.CheckIfPossible(rawText, maxAvailableCubes);
        Assert.That(result, Is.EqualTo(expected));

    }


    [Test]
    public void Day2Part1_CheckIfPossible_WithSampleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 2, part: 1);
        ExtractionData maxAvailableCubes = new(12, 13, 14);
        const int expected = 8;

        int result = Part1.CheckIfPossible(rawText, maxAvailableCubes);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day2Part1_CheckIfPossible_WithPuzzleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 2, part: 1);
        ExtractionData maxAvailableCubes = new(12, 13, 14);
        const int expected = 2476;

        int result = Part1.CheckIfPossible(rawText, maxAvailableCubes);

        Assert.That(result, Is.EqualTo(expected));
    }
}
