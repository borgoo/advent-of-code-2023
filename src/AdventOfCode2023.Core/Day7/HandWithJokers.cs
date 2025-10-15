using static AdventOfCode2023.Core.Day7.Day7;

namespace AdventOfCode2023.Core.Day7;

internal record HandWithJokers : Hand {

    const char _joker = 'J';

    public HandWithJokers(string cards, int bid) : base(cards, bid){
        _cardValues[_joker] = -1; // jokers are the lowest cards
    }

   protected override HandTypeEnum GetHandType(string cards) {

        HandTypeEnum currHandType = base.GetHandType(cards);

        KeyValuePair<char, int>[] bestCards = [.. _foundCards.OrderByDescending(x => x.Value).Where(x => x.Key != _joker).Take(2)];
        int bestCard = bestCards[0].Value;
        int secondBestCard = bestCards[1].Value;
        int numOfJokers = _foundCards[_joker];

        HandTypeEnum improvedHandType = HandTypeEnum.HighCard;

        if(bestCard == 4 && numOfJokers == 1) improvedHandType = HandTypeEnum.FiveOfAKind;
        else if(bestCard == 3 && numOfJokers == 2) improvedHandType = HandTypeEnum.FiveOfAKind;
        else if(bestCard == 3 && numOfJokers == 1) improvedHandType = HandTypeEnum.FourOfAKind;
        else if(bestCard == 2 && numOfJokers == 3) improvedHandType = HandTypeEnum.FiveOfAKind;
        else if(bestCard == 2 && numOfJokers == 2) improvedHandType = HandTypeEnum.FourOfAKind;
        else if(bestCard == 2 && secondBestCard == 1 && numOfJokers == 1) improvedHandType = HandTypeEnum.ThreeOfAKind;
        else if(bestCard == 2 && secondBestCard == 2 && numOfJokers == 1) improvedHandType = HandTypeEnum.FullHouse;
        else if(bestCard == 1){
            if(numOfJokers == 4) improvedHandType = HandTypeEnum.FiveOfAKind;
            else if(numOfJokers == 3) improvedHandType = HandTypeEnum.FourOfAKind;
            else if(numOfJokers == 2) improvedHandType = HandTypeEnum.ThreeOfAKind;
            else if(numOfJokers == 1) improvedHandType = HandTypeEnum.OnePair;
        }      

        return improvedHandType > currHandType ? improvedHandType : currHandType;

    
    }

    
}