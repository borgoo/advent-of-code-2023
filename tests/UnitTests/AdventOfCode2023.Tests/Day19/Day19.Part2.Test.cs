using static AdventOfCode2023.Core.Day19.Day19; 
 
namespace AdventOfCode2023.Tests.Day19; 
 
public class Day19Part2Test 
{ 

    [Test] 
    public void Day19Part2_GetNumOfDistinctCombinationsThatWillBeAccepted_WhenThereIsJustOneLessThanCondition_ThenReturnsAllTheCombinationsWithTheSConstraint() 
    { 
        string rawText = "in{s<2:A,R}";
        const long expected = (long)4000*4000*4000*1;
 
        var result = Part2.GetNumOfDistinctCombinationsThatWillBeAccepted(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
    
    [Test] 
    public void Day19Part2_GetNumOfDistinctCombinationsThatWillBeAccepted_WhenThereIsJustOneGraterThanCondition_ThenReturnsAllTheCombinationsWithTheSConstraint() 
    { 
        string rawText = "in{s>3999:A,R}";
        const long expected = (long)4000*4000*4000*1;
 
        var result = Part2.GetNumOfDistinctCombinationsThatWillBeAccepted(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
    [Test] 
    public void Day19Part2_GetNumOfDistinctCombinationsThatWillBeAccepted_WhenThereAreMultipleConditionsOnASingleWorkflow_ThenReturnsAllTheCombinationsWithTheSConstraint() 
    { 
        string rawText = "in{s>3999:A,x<3:A,R}";
        //just the ones where s = 4000 and each other is free + where x = 1,2 and the s < 4000  (<= 3999)
        const long expected = ((long)4000*4000*4000*1) + ((long)2*4000*4000*3999);
 
        var result = Part2.GetNumOfDistinctCombinationsThatWillBeAccepted(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
 
    [Test] 
    public void Day19Part2_GetNumOfDistinctCombinationsThatWillBeAccepted_WithSampleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadSampleInput(day: 19, part: 1); 
        const long expected = 167409079868000; 
 
        var result = Part2.GetNumOfDistinctCombinationsThatWillBeAccepted(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
    [Test] 
    public void Day19Part2_GetNumOfDistinctCombinationsThatWillBeAccepted_WithPuzzleInput_ReturnsExpectedValue() 
    { 
        string rawText = TestDataHelper.LoadPuzzleInput(day: 19, part: 1); 
        const long expected = 130303473508222; 
 
        var result = Part2.GetNumOfDistinctCombinationsThatWillBeAccepted(rawText); 
 
        Assert.That(result, Is.EqualTo(expected)); 
    } 
} 
