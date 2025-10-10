using static AdventOfCode2023.Core.Day3.Day3;

namespace AdventOfCode2023.Tests.Day3;

public class Day3Part2Test {


    private static IEnumerable<TestCaseData> NoGearTestCases()
    {
        yield return new TestCaseData("1234567890");
        yield return new TestCaseData("...");
        yield return new TestCaseData("...455..");
        yield return new TestCaseData("...455..");
        yield return new TestCaseData($"..455..{Environment.NewLine}.......");
        yield return new TestCaseData($"..pde..{Environment.NewLine}..455..{Environment.NewLine}.......");
    }

    [TestCaseSource(nameof(NoGearTestCases))]
    public void Day3Part2_FindGearRatio_WhenNoGear_ThenReturns0(string rawText) {
        int expected = 0;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> GearsOnlyTestCases()
    {
        yield return new TestCaseData("*");
        yield return new TestCaseData("***");
        yield return new TestCaseData("*..*");
        yield return new TestCaseData($"*..*{Environment.NewLine}....");
    }
    
    [TestCaseSource(nameof(GearsOnlyTestCases))]
    public void Day3Part2_FindGearRatio_WhenGearsOnly_ThenReturns0(string rawText) {
        int expected = 0;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> LessThan2NumbersPerGear()
    {
        yield return new TestCaseData("*123*");
        yield return new TestCaseData("*123");
        yield return new TestCaseData($"123.{Environment.NewLine}$*..");
    }

    [TestCaseSource(nameof(LessThan2NumbersPerGear))]
    public void Day3Part2_FindGearRatio_WhenThereAreLessThan2NumbersPerGear_ThenReturns0(string rawText) {
        int expected = 0;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part2_FindGearRatio_WhenThereAreMoreThan2NumbersPerGear_ThenReturns0() {
        string rawText = $"123.{Environment.NewLine}$*12.{Environment.NewLine}1456";
        int expected = 0;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part2_FindGearRatio_WhenGearIsIntheMiddleOfTheLine_ThenReturTheGearRatio() {
        string rawText = $".123.{Environment.NewLine}..*..{Environment.NewLine}.111.";
        int expected = 123*111;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part2_FindGearRatio_WhenOnlyOneValidGear_ThenReturnsTheGearRatio() {
        string rawText = $".123.{Environment.NewLine}....*{Environment.NewLine}...2.";
        int expected = 123*2;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part2_FindGearRatio_WhenThereIsASequenceOfValidGears_ThenReturnsTheGearRatio() {
        string rawText = $".123.{Environment.NewLine}....*{Environment.NewLine}...2.{Environment.NewLine}....*{Environment.NewLine}...2.";
        int expected = (123*2)+(2*2);
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    public void Day3Part2_FindGearRatio_WhenAGearNear4Numbers_ThenReturns0() {
        string rawText = $"..123..{Environment.NewLine}622*244{Environment.NewLine}..512..";
        int expected = 0;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    
    [Test]
    public void Day3Part2_FindGearRatio_WithSampleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 3, part: 1);
        int expected = 467835;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day3Part2_FindGearRatio_WithPuzzleInput_ReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 3, part: 1);
        int expected = 75220503;
        int result = Part2.FindGearRatio(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

}