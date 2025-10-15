namespace AdventOfCode2023.Core.Day7;

internal static partial class Day7 {

    
    internal record Hand : IComparable<Hand> {

        protected readonly static Dictionary<char, int> _cardValues = new() {
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'T', 10},
            {'J', 11},
            {'Q', 12},
            {'K', 13},
            {'A', 14}
        };
            
        internal enum HandTypeEnum {
            HighCard = 0,
            OnePair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            FullHouse = 4,
            FourOfAKind = 5,
            FiveOfAKind = 6
        }

        public int Bid {get; init;}
        public string Cards {get; init;}
        public HandTypeEnum HandType {get; init;}

        public Hand(string cards, int bid) {

            Bid = bid;
            Cards = cards;
            HandType = GetHandType(cards);

        }

        protected readonly Dictionary<char, int> _foundCards = new() {
            {'2', 0},
            {'3', 0},
            {'4', 0},
            {'5', 0},
            {'6', 0},
            {'7', 0},
            {'8', 0},
            {'9', 0},
            {'T', 0},
            {'J', 0},
            {'Q', 0},
            {'K', 0},
            {'A', 0}
        };

        protected virtual HandTypeEnum GetHandType(string cards) {

            HashSet<char> _pairs = [];

            HandTypeEnum currHandType = HandTypeEnum.HighCard;
            foreach(char card in cards) {
                _foundCards[card]++;
                int c = _foundCards[card];
                if(c == 2) _pairs.Add(card);
                if(currHandType == HandTypeEnum.HighCard && c == 2) currHandType = HandTypeEnum.OnePair;
                else if( currHandType == HandTypeEnum.OnePair && _pairs.Count > 1) currHandType = HandTypeEnum.TwoPair;
                else if(currHandType == HandTypeEnum.OnePair && c == 3) currHandType = HandTypeEnum.ThreeOfAKind;
                else if(currHandType == HandTypeEnum.TwoPair && c == 3) currHandType = HandTypeEnum.FullHouse;
                else if(currHandType == HandTypeEnum.ThreeOfAKind && c == 2) currHandType = HandTypeEnum.FullHouse;
                else if(currHandType == HandTypeEnum.ThreeOfAKind && c == 4) currHandType = HandTypeEnum.FourOfAKind;
                else if(currHandType == HandTypeEnum.FourOfAKind && c == 5) currHandType = HandTypeEnum.FiveOfAKind;

            }
            
            return currHandType;
        }

        public int CompareTo(Hand? other)
        {
            const int thisWin = 1, otherWin = -1, same = 0;

            if(other is null) return thisWin;
            if(this.Cards == other.Cards) return same;
            if(this.HandType != other.HandType) return this.HandType > other.HandType ? thisWin : otherWin;

            for(int i = 0; i < this.Cards.Length; i++) {
                if(_cardValues[this.Cards[i]] != _cardValues[other.Cards[i]]) 
                    return _cardValues[this.Cards[i]] > _cardValues[other.Cards[i]] ? thisWin : otherWin;
            }

            throw new NotImplementedException("Unexpected case.");
        }
    }


}