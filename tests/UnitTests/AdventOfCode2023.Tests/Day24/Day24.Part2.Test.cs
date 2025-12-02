using static AdventOfCode2023.Core.Day24.Day24; 
 
namespace AdventOfCode2023.Tests.Day24; 
 
public class Day24Part2Test 
{ 
    [Test] 
    public void Day24Part2_TailorMadeSolution_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 24, part: 1); 
        const long expected = 47; 
 
        var result = Part2.TailorMadeSolution(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day24Part2_TailorMadeSolution_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 24, part: 1); 
        const long expected = 983620716335751; 
 
        var result = Part2.TailorMadeSolution(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
