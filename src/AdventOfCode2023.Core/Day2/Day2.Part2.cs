namespace AdventOfCode2023.Core.Day2;

internal static partial class Day2 {

    internal static class Part2 {

        internal static int CheckIfPossible(string rawText) {

            IReadOnlyList<GameData> gamesData = GetGamesData(rawText);

            int sumOfPowers = gamesData
                .Select(gameData => 
                    gameData.ExtractionData.Max(extractionData => extractionData.Red) 
                    * gameData.ExtractionData.Max(extractionData => extractionData.Green)
                    * gameData.ExtractionData.Max(extractionData => extractionData.Blue)
                )
                .Sum();

            return sumOfPowers;
        }
    }
}