using static AdventOfCode2023.Core.Day20.Day20; 
 
namespace AdventOfCode2023.Tests.Day20; 
 
public class Day20Part2Test 
{ 
 
    [Test] 
    public void Day20Part2_FindLCMForSubCircuitsHighOutputSignal_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 20, part: 1); 
        const long expected = 229215609826339; 
 
        var result = Part2.FindLCMForSubCircuitsHighOutputSignal(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
