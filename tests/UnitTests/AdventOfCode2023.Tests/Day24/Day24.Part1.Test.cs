using static AdventOfCode2023.Core.Day24.Day24; 
 
namespace AdventOfCode2023.Tests.Day24; 
 
public class Day24Part1Test 
{ 

     
    [Test] 
    public void Day24Part1_CountNumOfIntersections_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 24, part: 1); 
        const long testAreaMin = 7;
        const long testAreaMax = 27;
        const long expected = 2;


        var result = Part1.CountNumOfIntersections(rawText, testAreaMin, testAreaMax); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day24Part1_CountNumOfIntersections_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 24, part: 1); 
        const long expected = 11995; 
        const long wrongAnswer = 91;
        const long wrongAnswer2 = 134;
 
        var result = Part1.CountNumOfIntersections(rawText); 
 
        Assert.That(result, Is.Not.EqualTo(wrongAnswer)); 
        Assert.That(result, Is.GreaterThan(wrongAnswer2)); 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
