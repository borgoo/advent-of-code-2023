using static AdventOfCode2023.Core.Day20.Day20; 
 
namespace AdventOfCode2023.Tests.Day20; 
 
public class Day20Part1Test 
{
    private static readonly string[] _moreInterestingExampleArr = [
            "broadcaster -> a",
            "%a -> inv, con",
            "&inv -> b",
            "%b -> con",
            "&con -> output"
    ];

    private static readonly string _moreInterestingExample = String.Join(Environment.NewLine, _moreInterestingExampleArr); 


    [Test]
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WhenMoreInterestingInput_ThenReturns11687500() {

        string rawText = _moreInterestingExample;

        const long expected = 11687500;
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }
  
    [Test]
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WhenMoreInterestingInputButPressedOneTimeOnly_ThenReturns16() {

        const int pushes = 1;
        string rawText = _moreInterestingExample;

        const long expected = 16; //4 x 4
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText, pushes);
        Assert.That(result, Is.EqualTo(expected));

    }
  
    [Test]
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WhenMoreInterestingInputButPressedTwoTimes_ThenReturns48() {

        const int pushes = 2;
        string rawText = _moreInterestingExample;

        const long expected = 48;  //8 x 6
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText, pushes);
        Assert.That(result, Is.EqualTo(expected));

    }


    [Test]
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WhenMoreInterestingInputButPressedThreeTimes_ThenReturns48()
    {

        const int pushes = 3;
        string rawText = _moreInterestingExample;

        const long expected = 117;  //13 x 9
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText, pushes);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test] 
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WithSampleInputPushed1Time_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 20, part: 1); 
        const long expected = 32; 
 
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText, 1); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WithSampleInputPushed1000Times_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 20, part: 1); 
        const long expected = 32000000; 
 
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day20Part1_GetTotalMulOfHighAndLowPulses_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 20, part: 1); 
        const long expected = 866435264; 
 
        var result = Part1.GetTotalMulOfHighAndLowPulses(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
