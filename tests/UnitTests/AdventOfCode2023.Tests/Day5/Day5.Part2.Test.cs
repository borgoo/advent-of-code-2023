using static AdventOfCode2023.Core.Day5.Day5;
namespace AdventOfCode2023.Tests.Day5;

public class Day5Part2Test
{
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedIs10To15WithOneOnlyMapFrom8To9_ThenReturns10(){
        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}100 8 2{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 10;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedIs10To15WithOneOnlyMapFrom25To34_ThenReturns10(){
        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}100 25 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 10;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeIncludesMapRange_ThenReturns20(){
        string text =$"seeds: 20 20{Environment.NewLine}seed to soil:{Environment.NewLine}100 25 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 20;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeIncludedInMapRange_ThenReturns102(){

        string text =$"seeds: 27 3{Environment.NewLine}seed to soil:{Environment.NewLine}100 25 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 102;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeStartsInMapButExtendsBeyond_ThenReturns35(){

        string text =$"seeds: 30 10{Environment.NewLine}seed to soil:{Environment.NewLine}100 25 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 35;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeStartsBeforeMapButEndsInside_ThenReturns20(){

        string text =$"seeds: 20 8{Environment.NewLine}seed to soil:{Environment.NewLine}100 25 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 20;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeMappedThroughMultipleMaps_ThenReturns50(){

        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}20 10 5{Environment.NewLine}soil to fertilizer:{Environment.NewLine}30 20 5{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:{Environment.NewLine}50 30 5";
        const long expected = 50;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeSplitAcrossTwoMapsInFirstMap_ThenReturns15(){

        string text =$"seeds: 10 10{Environment.NewLine}seed to soil:{Environment.NewLine}100 10 5{Environment.NewLine}soil to fertilizer:{Environment.NewLine}200 100 5{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 15;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenSeedRangeSplitInSecondMap_ThenReturns105(){

        string text =$"seeds: 10 10{Environment.NewLine}seed to soil:{Environment.NewLine}20 10 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}100 20 5{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 25;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenMultipleMapsWithGaps_ThenReturns10(){

        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}50 20 5{Environment.NewLine}soil to fertilizer:{Environment.NewLine}100 60 5{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:{Environment.NewLine}200 30 5";
        const long expected = 10;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenChainedMapsAllOverlapping_ThenReturns500(){

        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}100 10 5{Environment.NewLine}soil to fertilizer:{Environment.NewLine}200 100 5{Environment.NewLine}fertilizer to water:{Environment.NewLine}300 200 5{Environment.NewLine}water to light:{Environment.NewLine}400 300 5{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:{Environment.NewLine}500 400 5";
        const long expected = 500;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenRangeSplitIntoThreePartsAcrossMap_ThenReturns20(){

        string text =$"seeds: 10 20{Environment.NewLine}seed to soil:{Environment.NewLine}100 15 10{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 10;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WhenMultipleNonOverlappingMapsInSameCategory_ThenReturns10(){

        string text =$"seeds: 10 5{Environment.NewLine}seed to soil:{Environment.NewLine}100 5 3{Environment.NewLine}200 20 5{Environment.NewLine}soil to fertilizer:{Environment.NewLine}fertilizer to water:{Environment.NewLine}water to light:{Environment.NewLine}light to temperature:{Environment.NewLine}temperature to humidity:{Environment.NewLine}humidity to location:";
        const long expected = 10;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    
    [Test]
    public void Day5Part2_GetLowestLocationNumber_WithSampleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadSampleInput(day: 5, part: 1);
        const long expected = 46;
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day5Part2_GetLowestLocationNumber_WithPuzzleInput_ReturnsExpectedValue(){
        string text = TestDataHelper.LoadPuzzleInput(day: 5, part: 1);
        const long expected = 37384986; 
        var day5 = new Part2();
        var result = day5.GetLowestLocationNumber(text);
        Assert.That(result, Is.EqualTo(expected));
    }
}