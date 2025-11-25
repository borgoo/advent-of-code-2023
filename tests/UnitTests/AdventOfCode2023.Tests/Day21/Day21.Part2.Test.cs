using static AdventOfCode2023.Core.Day21.Day21; 
 
namespace AdventOfCode2023.Tests.Day21; 
 
public class Day21Part2Test 
{ 

    [TestCase(6,16)] 
    [TestCase(10, 50)] 
    [TestCase(50, 1594)] 
    [TestCase(100, 6536)] 
    [TestCase(500, 167004)] 
    [TestCase(1000, 668697)] 
    [TestCase(5000, 16733044)] 
    public void Day21Part2_Solve_WithSampleInput_ReturnsExpectedValue(int neededSteps, long expected) 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 21, part: 1); 
 
        var result = Part2.CountDistinctGardenPlotsOnInfiniteGrid(rawText, neededSteps); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day21Part2_Solve_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 21, part: 1); 
        const long expected = 610158187362102; 

        var result = Part2.TailorMadeSolution(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
