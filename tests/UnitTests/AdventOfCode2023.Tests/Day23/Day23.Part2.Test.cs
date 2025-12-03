using static AdventOfCode2023.Core.Day23.Day23; 
 
namespace AdventOfCode2023.Tests.Day23; 
 
public class Day23Part2Test 
{ 
    [Test] 
    public void Day23Part2_GetLongestPath_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 23, part: 1); 
        const long expected = 154; 
 
        var result = new Part2().GetLongestPath(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test]
    public void Day23Part2_GetLongestPath_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 23, part: 1);
        const long expected = 6418;

        var result = new Part2().GetLongestPath(rawText);

        Assert.That(result, Is.EqualTo(expected));
    }
} 
