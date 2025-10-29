using static AdventOfCode2023.Core.Day18.Day18; 
 
namespace AdventOfCode2023.Tests.Day18; 
 
public class Day18Part2Test 
{ 
    [Test] 
    public void Day18Part2_Solve_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 18, part: 1); 
        const long expected = 952408144115; 
 
        var result = new Part2().GetArea(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day18Part2_Solve_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 18, part: 1); 
        const long expected = 201398068194715; 
 
        var result = new Part2().GetArea(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
