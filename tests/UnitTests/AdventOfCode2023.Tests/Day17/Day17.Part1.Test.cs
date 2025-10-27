using static AdventOfCode2023.Core.Day17.Day17;

namespace AdventOfCode2023.Tests.Day17;

public class Day17Part1Test
{
    [Test]
    public void Day17Part1_GetLeastHeatLoss_WhenThereIsOnly1Heat_ThenReturnsShorterPath(){
        const string inputRaw = @"  11111111111111111
                                    11111111111111111
                                    11111111111111111
                                    11111111111111111";

        string input = String.Join(Environment.NewLine, inputRaw.Split(Environment.NewLine).Select(line => line.Trim()));
        const int expected = 21;
        int result = new Part1().GetLeastHeatLoss(input);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    [Test]
    public void Day17Part1_GetLeastHeatLoss_WhenThereIsAShorterButHeaterPath_ThenReturns65(){
        const string inputRaw = @"  19999999999999999
                                    19991111111119999
                                    19991999999919999
                                    11111999999911111";

        string input = String.Join(Environment.NewLine, inputRaw.Split(Environment.NewLine).Select(line => line.Trim()));
        const int expected = 65;
        int result = new Part1().GetLeastHeatLoss(input);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day17Part1_GetLeastHeatLoss_WhenThereIsAFalseHeaterPath_ThenReturns65(){
        const string inputRaw = @"  11199999999999999
                                    19991111111119999
                                    19991999999919999
                                    11111999999911111";

        string input = String.Join(Environment.NewLine, inputRaw.Split(Environment.NewLine).Select(line => line.Trim()));
        const int expected = 65;
        int result = new Part1().GetLeastHeatLoss(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day17Part1_GetLeastHeatLoss_WithSampleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadSampleInput(day: 17, part: 1);
        int expected = 102;
        int result = new Part1().GetLeastHeatLoss(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day17Part1_GetLeastHeatLoss_WithPuzzleInput_ReturnsExpectedValue()
    {
        string rawText = TestDataHelper.LoadPuzzleInput(day: 17, part: 1);
        int expected = 1244;
        int result = new Part1().GetLeastHeatLoss(rawText);
        Assert.That(result, Is.EqualTo(expected));
    }
   
    
}

