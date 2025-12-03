using static AdventOfCode2023.Core.Day23.Day23; 
 
namespace AdventOfCode2023.Tests.Day23; 
 
public class Day23Part1Test 
{ 
    [Test] 
    public void Day23Part1_GetLongestPath_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 23, part: 1); 
        const long expected = 94; 
 
        var result = new Part1().GetLongestPath(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day23Part1_GetLongestPath_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 23, part: 1); 
        const long expected = 2294; 
 
        var result = new Part1().GetLongestPath(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
