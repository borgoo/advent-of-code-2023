using static AdventOfCode2023.Core.Day3.Day3;
namespace AdventOfCode2023.Tests.Day3;

public class Day3Part1Test {

    [Test]
    public void Day3Part1_SumAllPartNumbers_WhenJustANumber_ThenReturns0() {
        string rawText = "429";
        int expected = 0;
        int result = Part1.SumAllPartNumbers(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part1_SumAllPartNumbers_WhenJustEmptySpaces_ThenReturns0() {
        string rawText = "....";
        int expected = 0;
        int result = Part1.SumAllPartNumbers(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
  
    [TestCase("456....")]
    [TestCase("....456")]
    [TestCase("....456....")]
    [TestCase("...........\n....456....\n...........")]
    [TestCase("$..........\n....456....\n..........*")]
    public void Day3Part1_SumAllPartNumbers_WhenNotValidPartsOnly_ThenReturns0(string rawText) {
       
        int expected = 0;
        int result = Part1.SumAllPartNumbers(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> ValidPartsOnlyTestCases()
    {
        yield return new TestCaseData("456*", 456);
        yield return new TestCaseData("}456", 456);
        yield return new TestCaseData($"456{Environment.NewLine}*..", 456);
        yield return new TestCaseData($"456{Environment.NewLine}.*.", 456);
        yield return new TestCaseData($"456{Environment.NewLine}..+", 456);
        yield return new TestCaseData($"456.{Environment.NewLine}...+", 456);
    }

    [TestCaseSource(nameof(ValidPartsOnlyTestCases))]
    public void Day3Part1_SumAllPartNumbers_WhenValidPartsOnly_ThenReturnsTheSumOfThem(string rawText, int expected) {
        int result = Part1.SumAllPartNumbers(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part1_SumAllPartNumbers_WithSampleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 3, part: 1);
        int expected = 4361;

        int result = Part1.SumAllPartNumbers(rawText);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part1_SumAllPartNumbers_WithPuzzleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 3, part: 1);
        int expected = 509115;

        int result = Part1.SumAllPartNumbers(rawText);

        Assert.That(result, Is.EqualTo(expected));
    }

}