using static AdventOfCode2023.Core.Day10.Day10;

namespace AdventOfCode2023.Tests.Day10;

public class Day10Part2Test {

    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WhenSimplePipe_ThenReturns4() {

        string text = @"...........
                        .S-------7.
                        .|F-----7|.
                        .||.....||.
                        .||.....||.
                        .|L-7.F-J|.
                        .|..|.|..|.
                        .L--J.L--J.
                        ...........";
                        
        const int expected = 4;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.EqualTo(expected));

    }
    
    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WhenInternalExternalSpaceIsPresent_ThenReturns4() {
          
        string text = @"..........
                        .S------7.
                        .|F----7|.
                        .||....||.
                        .||....||.
                        .|L-7F-J|.
                        .|..||..|.
                        .L--JL--J.
                        ..........";
                        
        const int expected = 4;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WhenMoreThanOnePathIsPresent_ThenReturns4() {

        string text = @".F--7
                        .S-7|
                        .|.||
                        .L--J
                        .....";
                        
        const int expected = 4;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WhenComplexPathIsPresent_ThenReturns10() {

        string text = @"FF7FSF7F7F7F7F7F---7
                        L|LJ||||||||||||F--J
                        FL-7LJLJ||||||LJL-77
                        F--JF--7||LJLJ7F7FJ-
                        L---JF-JLJ.||-FJLJJ7
                        |F|F-JF---7F7-L7L|7|
                        |FFJF7L7F-JF7|JL---7
                        7-L-JL7||F7|L7F-7F7|
                        L.L7LFJ|||||FJL7||LJ
                        L7JLJL-JLJLJL--JLJ.L";
                        
        const int expected = 10;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    
    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WithSampleInput_ReturnsExpectedValue() {

        string text = TestDataHelper.LoadSampleInput(day: 10, part: 2);
        const long expected = 8;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day10Part2_GetNumOfTilesInTheLoop_WithPuzzleInput_ReturnsExpectedValue() {

        string text = TestDataHelper.LoadPuzzleInput(day: 10, part: 1);
        const long wrongResult = 3;
        const long expected = 285;

        var result = Part2.GetNumOfTilesInTheLoop(text);

        Assert.That(result, Is.Not.EqualTo(wrongResult));
        Assert.That(result, Is.EqualTo(expected));
    }

}
