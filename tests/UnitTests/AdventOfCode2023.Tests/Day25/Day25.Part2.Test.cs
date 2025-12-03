using static AdventOfCode2023.Core.Day25.Day25; 
 
namespace AdventOfCode2023.Tests.Day25; 
 
public class Day25Part2Test 
{ 
    [Test] 
    public void Day25Part2_Solve_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 25, part: 1); 
        const long expected = -1; 
 
        var result = Part2.Solve(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day25Part2_Solve_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 25, part: 1); 
        const long expected = -1; 
 
        var result = Part2.Solve(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
