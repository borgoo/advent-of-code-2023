using System.Runtime.InteropServices;
using static AdventOfCode2023.Core.Day14.Day14;
namespace AdventOfCode2023.Tests.Day14;

public class Day14Part2Test
{
 
    [Test]
    public void Day14Part2_GetTotalLoad_WhenSampleInputAfter1Cycle_ThenReturns87() {
        string rawText = TestDataHelper.LoadSampleInput(day: 14, part: 1);
        const int expected = 87;
        const int numOfCycles = 1;
        int result = new Part2().GetTotalLoad(rawText, numOfCycles);
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Day14Part2_GetTotalLoad_WhenSampleInputAfter2Cycles_ThenReturns69() {
        string rawText = TestDataHelper.LoadSampleInput(day: 14, part: 1);
        const int expected = 69;
        const int numOfCycles = 2;
        int result = new Part2().GetTotalLoad(rawText, numOfCycles);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day14Part2_GetTotalLoad_WhenSampleInputAfter3Cycles_ThenReturns69() {
        string rawText = TestDataHelper.LoadSampleInput(day: 14, part: 1);
        const int expected = 69;
        const int numOfCycles = 3;
        int result = new Part2().GetTotalLoad(rawText, numOfCycles);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day14Part2_GetTotalLoad_WhenSampleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadSampleInput(day: 14, part: 1);
        const int expected = 64;
        int result = new Part2().GetTotalLoad(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day14Part2_GetTotalLoad_WhenPuzzleInput_ThenReturnsExpectedValue() {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 14, part: 1);
        const int expected = 88371;
        int result = new Part2().GetTotalLoad(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
}