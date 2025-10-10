namespace AdventOfCode2023.Core.Day4;

internal static partial class Day4 {

    internal static class Part2 {

        private const long _empty = -1;

        private static long GetNumOfGeneratedCardsByCardId(long[] dp, string[] lines, int cardId, int lastCardId) {

            if(dp[cardId] != _empty) return dp[cardId];

            string line = lines[cardId-1];
            int c = GetNumOfWinningNumbersPossessed(line);
            bool isWinningScratchCard = IsWinningScratchCard(c);
            if(!isWinningScratchCard) {
                dp[cardId] = 0;
                return dp[cardId];
            }

            long result = 0;
            int startingFrom = cardId + 1;
            int reaching = Math.Min(cardId + c, lastCardId);
            for(int copyId = startingFrom; copyId <= reaching; copyId++){
                result += 1 + GetNumOfGeneratedCardsByCardId(dp, lines, copyId, lastCardId);
            }

            dp[cardId] = result;
            return dp[cardId];

        }




       internal static long GetNumOfTotalGeneratedCards(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            int startingCards = lines.Length;
            int firstCardId = 1;
            int lastCardId = lines.Length;
            long[] dp = new long[lastCardId+1]; // dp[cardId] = number of generated cards by cardId
            Array.Fill(dp, _empty);
            long result = startingCards;
            for(int currCardId = firstCardId; currCardId <= lastCardId; currCardId++) {
                result += GetNumOfGeneratedCardsByCardId(dp, lines, currCardId, lastCardId);
            }

            return result;


       }
    }
}