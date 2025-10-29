using static AdventOfCode2023.Core.Day18.Day18; 
 
namespace AdventOfCode2023.Tests.Day18; 
 
public class Day18Part1Test 
{ 
    
    [Test] 
    public void Day18Part1_GetArea_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 18, part: 1); 
        const long expected = 62; 
 
        var result = new Part1().GetArea(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day18Part1_GetArea_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 18, part: 1); 
        const long expected = 46394; 
 
        var result = new Part1().GetArea(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
