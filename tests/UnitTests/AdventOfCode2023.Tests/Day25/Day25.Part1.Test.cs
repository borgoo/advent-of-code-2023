using static AdventOfCode2023.Core.Day25.Day25; 
 
namespace AdventOfCode2023.Tests.Day25; 
 
public class Day25Part1Test 
{ 
    [Test] 
    public void Day25Part1_TailorMadeSampleInput_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 25, part: 1); 
        const long expected = 54; 
 
        var result = Part1.TailorMadeSampleInput(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day25Part1_TailorMadePuzzleInput_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 25, part: 1); 
        const long expected = 533628; 
 
        var result = Part1.TailorMadePuzzleInput(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
