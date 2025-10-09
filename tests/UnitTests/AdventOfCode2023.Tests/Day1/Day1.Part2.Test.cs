namespace AdventOfCode2023.Tests.Day1;

public class Day1Part2Test
{
    [TestCase("1abc2", 12)]
    [TestCase("342", 32)]
    [TestCase("flcffqpthznrhmxklztqtdqh2", 22)]
    [TestCase("1flcffqpthznrhmxklztqtdq", 11)]
    public void Day1Part2_SumAllCalibrationValues_WhenDoesNotContainsSpelledNumbers_ThenReturnsTheExpectedValue(string text, long expected){

        var result = Core.Day1.Day1.Part2.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("oneandtwo", 12)]
    [TestCase("twoandthree", 23)]
    [TestCase("threeandfour", 34)]
    [TestCase("fourandfive", 45)]
    [TestCase("fiveandsix", 56)]
    [TestCase("sixandseven", 67)]
    [TestCase("sevenandeight", 78)]
    [TestCase("eightandnine", 89)]
    [TestCase("nine", 99)]
    [TestCase("oooneand3trefourfive", 15)]
    [TestCase("eighteight", 88)]
    public void Day1Part2_SumAllCalibrationValues_WhenContainsSpelledNumbersOnly_ThenReturnsTheExpectedValue(string text, long expected){
        var result = Core.Day1.Day1.Part2.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [TestCase("twone", 21)]
    [TestCase("eightwo", 82)]
    [TestCase("oneight", 18)]
    [TestCase("threeight", 38)]
    [TestCase("fiveight", 58)]
    [TestCase("nineight", 98)]
    [TestCase("sevenine", 79)]
    [TestCase("eighthree", 83)]
    [TestCase("1two", 12)]
    [TestCase("one2", 12)]
    [TestCase("9eight", 98)]
    [TestCase("seven3", 73)]
    [TestCase("7pqrstsixteen", 76)]
    [TestCase("eightwothree", 83)]
    [TestCase("xtwone3four", 24)]
    [TestCase("ontw1three", 13)]
    [TestCase("ontwthreeand2butalso", 32)]
    [TestCase("1onethwothreefourother", 14)]
    public void Day1Part2_SumAllCalibrationValues_WhenContainsSpelledNumbersAndNumbers_ThenReturnsTheExpectedValue(string text, long expected){
        var result = Core.Day1.Day1.Part2.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day1Part2_SumAllCalibrationValues_WithSampleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 1, part: 2);
        long expected = 281;

        var result = Core.Day1.Day1.Part2.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day1Part2_SumAllCalibrationValues_WithPuzzleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 1, part: 1);
        long expected = 54925;

        var result = Core.Day1.Day1.Part2.SumAllCalibrationValues(text);

        Assert.That(result, Is.EqualTo(expected));

    }
   
}