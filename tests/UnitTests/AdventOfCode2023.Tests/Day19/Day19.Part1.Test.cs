using static AdventOfCode2023.Core.Day19.Day19; 
 
namespace AdventOfCode2023.Tests.Day19; 
 
public class Day19Part1Test 
{ 
    [Test] 
    public void Day19Part1_SumAllRatingNumbersOfAcceptedParts_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 19, part: 1); 
        const long expected = 19114; 
 
        var result = Part1.SumAllRatingNumbersOfAcceptedParts(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day19Part1_SumAllRatingNumbersOfAcceptedParts_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 19, part: 1); 
        const long expected = 342650; 
 
        var result = Part1.SumAllRatingNumbersOfAcceptedParts(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
