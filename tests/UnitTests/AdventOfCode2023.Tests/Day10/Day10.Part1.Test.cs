using static AdventOfCode2023.Core.Day10.Day10;

namespace AdventOfCode2023.Tests.Day10;

public class Day10Part1Test {

    [Test]
    public void Day10Part1_GetFarthestDistance_WhenSimplePipe_ThenReturns4() {
        string text = @".....
                        .S-7.
                        .|.|.
                        .L-J.
                        .....";
                        
        const int expected = 4;

        var result = Part1.GetFarthestDistance(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Day10Part1_GetFarthestDistance_WhenMoreThanOnePathIsPresent_ThenReturns4() {
        string text = @".F--7
                        .S-7|
                        .|.||
                        .L--J
                        .....";
                        
        const int expected = 6;

        var result = Part1.GetFarthestDistance(text);

        Assert.That(result, Is.EqualTo(expected));

    }

    
    [Test]
    public void Day10Part1_GetFarthestDistance_WithSampleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadSampleInput(day: 10, part: 1);
        const long expected = 8;

        var result = Part1.GetFarthestDistance(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day10Part1_GetFarthestDistance_WithPuzzleInput_ReturnsExpectedValue() {
        string text = TestDataHelper.LoadPuzzleInput(day: 10, part: 1);
        const long wrongResult = 3;
        const long expected = 7030;

        var result = Part1.GetFarthestDistance(text);

        Assert.That(result, Is.Not.EqualTo(wrongResult));
        Assert.That(result, Is.EqualTo(expected));
    }

}
