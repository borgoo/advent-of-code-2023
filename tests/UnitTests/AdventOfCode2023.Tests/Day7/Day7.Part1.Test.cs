using static AdventOfCode2023.Core.Day7.Day7;
namespace AdventOfCode2023.Tests.Day7;

public class Day7Part1Test
{
    const int firstWins = 1, secondWins = -1, same = 0;
    [TestCase("32T3K", "T55J5", secondWins)]
    [TestCase("KK677", "KTJJT", firstWins)]
    [TestCase("T55J5", "QQQJA", secondWins)]    
    [TestCase("QQQJA", "QQQJA", same)]    
    public void Day7Part1_HandComparer_When1V1HandIsPlayed_ThenReturnsExpectedValue(string handA, string handB, int expected)
    {
        int result = Part1.HandComparer(new Hand(handA, 0), new Hand(handB, 0));
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day7Part1_CalculateTotalWinnings_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 7, part: 1);
        long expected = 6440;
        long result = Part1.CalculateTotalWinnings(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day7Part1_CalculateTotalWinnings_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 7, part: 1);
        long expected = 251029473; 
        long result = Part1.CalculateTotalWinnings(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}