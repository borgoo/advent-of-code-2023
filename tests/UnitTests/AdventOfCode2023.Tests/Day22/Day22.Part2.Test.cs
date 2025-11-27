using static AdventOfCode2023.Core.Day22.Day22; 
 
namespace AdventOfCode2023.Tests.Day22; 
 
public class Day22Part2Test 
{ 
    [Test] 
    public void Day22Part2_Solve_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 22, part: 1); 
        const long expected = 7; 
 
        var result = Part2.CountHowManyBreaksCanBeDisintegratedWithChainReaction(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day22Part2_Solve_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 22, part: 1); 
        const long expected = 96356; 
 
        var result = Part2.CountHowManyBreaksCanBeDisintegratedWithChainReaction(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
