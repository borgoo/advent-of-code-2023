using static AdventOfCode2023.Core.Day4.Day4;

namespace AdventOfCode2023.Tests.Day4;

public class Day4Part2Test {

    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenJustOneWinningCard_ThenReturns1() {

        string rawText = "Card 1: 1 2 3 4 17 | 83 86  6 31 17  9 48 53";
        long expected = 1;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenMultipleWinningInTheSameCard_ThenReturns1() {

        string rawText = "Card 1: 83 86  1 31 17  9 48 53 | 83 86  6 31 17  9 48 53";
        long expected = 1;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenJustOneLosingCard_ThenReturns1() {

        string rawText = "Card 1: 1 2 3 | 83 86  6 31 17  9 48 53";
        long expected = 1;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_When3NotWinningCards_ThenReturns3() {

        string rawText = $"Card 1: 1 2 3 | 83 86  6 31 17  9 48 53{Environment.NewLine}Card 2: 1 2 3 | 83 86  6 31 17  9 48 53{Environment.NewLine}Card 3: 1 2 3 | 83 86  6 31 17  9 48 53";
        long expected = 3;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenJustLastCardWins_ThenReturns3() {

        string rawText = $"Card 1: 1 2 3 | 83 86  6 31 17  9 48 53{Environment.NewLine}Card 2: 1 2 3 | 83 86  6 31 17  9 48 53{Environment.NewLine}Card 3: 17 2 9 | 83 86  6 31 17  9 48 53";
        long expected = 3;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenSampleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 4, part: 1);
        long expected = 30;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day4Part2_GetNumOfTotalGeneratedCards_WhenPuzzleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 4, part: 1);
        long expected = 13261850;
        long result = Part2.GetNumOfTotalGeneratedCards(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}
