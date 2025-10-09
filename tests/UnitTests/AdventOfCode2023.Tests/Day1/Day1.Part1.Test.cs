namespace AdventOfCode2023.Tests.Day1;

public class Day1Part1Test
{
    [TestCase("1abc2", 12)]
    [TestCase("nine58", 58)]
    [TestCase("342", 32)]
    [TestCase("flcffqpthznrhmxklztqtdqhone2", 22)]
    [TestCase("1flcffqpthznrhmxklztqtdqhone", 11)]
    public void Day1Part1_SumAllCalibrationValues_WithEdgeCases_ReturnsExpectedValue(string text, long expected)
    {
        var result = Core.Day1.Day1.Part1.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Day1Part1_SumAllCalibrationValues_WithSampleInput_Returns142()
    {
        string text = TestDataHelper.LoadSampleInput(day: 1, part: 1);
        const long expected = 142;

        var result = Core.Day1.Day1.Part1.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day1Part1_SumAllCalibrationValues_WithPuzzleInput_ReturnsExpectedValue()
    {
        string text = TestDataHelper.LoadPuzzleInput(day: 1, part: 1);
        const long expected = 55172; 

        var result = Core.Day1.Day1.Part1.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }
}