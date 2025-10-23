using static AdventOfCode2023.Core.Day13.Day13;
namespace AdventOfCode2023.Tests.Day13;

public class Day13Part2Test
{
    [Test]
    public void Day13Part2_GetNotesSum_WhenThereIsAVerticalReflection_ThenReturns5(){

        const string rawText = @"   #.##..##.
                                    ..#.##.#.
                                    ##......#
                                    ##......#
                                    ..#.##.#.
                                    ..##..##.
                                    #.#.##.#.";
        const int expected = 300;
        var result = new Part2().GetNotesSum(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day13Part2_GetNotesSum_WhenThereIsAnHorizontalReflection_ThenReturns400(){

        const string rawText = @"   #...##..#
                                    #....#..#
                                    ..##..###
                                    #####.##.
                                    #####.##.
                                    ..##..###
                                    #....#..#";
        const int expected = 100;
        var result = new Part2().GetNotesSum(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day13Part2_GetNotesSum_WhenSampleInput_ThenReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 13, part: 1);
        const int expected = 400;
        var result = new Part2().GetNotesSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day13Part2_GetNotesSum_WhenPuzzleInput_ThenReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 13, part: 1);
        const int expected = 37478;
        var result = new Part2().GetNotesSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }

   

    
}