using static AdventOfCode2023.Core.Day17.Day17;

namespace AdventOfCode2023.Tests.Day17;

public class Day17Part2Test
{
    [Test]
    public void Day17Part2_GetLeastHeatLoss_WhenTheBorderIsAColdestPath_ThenReturns71(){
        const string inputRaw = @"  111111111111
                                    999999999991
                                    999999999991
                                    999999999991
                                    999999999991";

        string input = String.Join(Environment.NewLine, inputRaw.Split(Environment.NewLine).Select(line => line.Trim()));
        const int expected = 71;
        int result = new Part2().GetLeastHeatLoss(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day17Part2_GetLeastHeatLoss_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 17, part: 1);
        int expected = 94;
        int result = new Part2().GetLeastHeatLoss(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day17Part2_GetLeastHeatLoss_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 17, part: 1);
        int wrongAnswer = 1410;
        int expected = 1367;
        int result = new Part2().GetLeastHeatLoss(rawText);
        Assert.That(result, Is.LessThan(wrongAnswer));
        Assert.That(result, Is.EqualTo(expected));
    }
   
    
}

