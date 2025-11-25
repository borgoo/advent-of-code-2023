using static AdventOfCode2023.Core.Day21.Day21; 
 
namespace AdventOfCode2023.Tests.Day21; 
 
public class Day21Part1Test 
{ 

    [TestCase(1, 2)] 
    [TestCase(2, 4)] 
    [TestCase(6, 16)] 
    public void Day21Part1_Solve_WithSampleInput_ReturnsExpectedValue(int neededSteps, long expected) 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 21, part: 1); 
 
        var result = Part1.CountDistinctGardenPlots(rawText, neededSteps); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day21Part1_Solve_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 21, part: 1); 
        const long expected = 3689; 
        const long wrongAnswer = 3537;
 
        var result = Part1.CountDistinctGardenPlots(rawText); 
 
        Assert.That(result, Is.GreaterThan(wrongAnswer)); 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
