using static AdventOfCode2023.Core.Day13.Day13;
namespace AdventOfCode2023.Tests.Day13;

public class Day13Part1Test
{
    [Test]
    public void Day13Part1_ColumnsToRows_WhenGridIsLxL_ThenReturnsRotatedGrid(){
        string[] grid = [
            "ABC",
            "DEF",
            "GHI"
        ];
        string[] expected = [
            "ADG",
            "BEH",
            "CFI"
        ];

        var result = Part1.ColumnsToRows(grid, grid.Length, grid[0].Length);

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day13Part1_ColumnsToRows_WhenGridIsMxN_ThenReturnsRotatedGrid(){
        string[] grid = [
            "AB",
            "CD",
            "EF"
        ];
        string[] expected = [
            "ACE",
            "BDF"
        ];
        var result = Part1.ColumnsToRows(grid, grid.Length, grid[0].Length);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day13Part1_GetNotesSum_WhenThereIsAVerticalReflection_ThenReturns5(){

        const string rawText = @"   #.##..##.
                                    ..#.##.#.
                                    ##......#
                                    ##......#
                                    ..#.##.#.
                                    ..##..##.
                                    #.#.##.#.";
        const int expected = 5;
        var result = new Part1().GetNotesSum(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day13Part1_GetNotesSum_WhenThereIsAnHorizontalReflection_ThenReturns400(){

        const string rawText = @"   #...##..#
                                    #....#..#
                                    ..##..###
                                    #####.##.
                                    #####.##.
                                    ..##..###
                                    #....#..#";
        const int expected = 400;
        var result = new Part1().GetNotesSum(rawText);
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day13Part1_GetNotesSum_WhenSampleInput_ThenReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 13, part: 1);
        const int expected = 405;
        var result = new Part1().GetNotesSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day13Part1_GetNotesSum_WhenPuzzleInput_ThenReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 13, part: 1);
        const int expected = 30575;
        var result = new Part1().GetNotesSum(text);
        Assert.That(result, Is.EqualTo(expected));
    }

   

    
}