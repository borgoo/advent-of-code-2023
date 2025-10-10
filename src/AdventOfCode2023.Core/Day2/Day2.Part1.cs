namespace AdventOfCode2023.Core.Day2;

internal static partial class Day2 {

    internal record ExtractionData(int Red, int Green, int Blue);
    private record GameData(int Id, IReadOnlyList<ExtractionData> ExtractionData);



    private static IReadOnlyList<GameData> GetGamesData(string rawText) {
        
        const int idStartIndex = 5;
        string[] lines = rawText.Split(Environment.NewLine);
        List<GameData> gamesData = [];
        foreach(string line in lines) {
            
            int pos = line.IndexOf(':');
            string tmp = line[idStartIndex..pos];
            int id = Convert.ToInt32(tmp);
            string[] extractions = line[(pos + 2)..].Split("; ");
            List<ExtractionData> extractionData = [];
            foreach(string extraction in extractions) {
                string[] cubes = extraction.Split(", ");
                int red = 0, green = 0, blue = 0;
                foreach(string cube in cubes) {
                    string[] cubeData = cube.Split(' ');
                    int cubeNumber = Convert.ToInt32(cubeData[0]);
                    string cubeColor = cubeData[1];

                    switch(cubeColor) {
                        case "red":
                            red += cubeNumber;
                            break;
                        case "green":
                            green += cubeNumber;
                            break;
                        case "blue":
                            blue += cubeNumber;
                            break;
                        default:
                            throw new ArgumentException($"Invalid cube color: {cubeColor}");
                    }
                }
                extractionData.Add(new ExtractionData(red, green, blue));
            }

            gamesData.Add(new GameData(id, extractionData));
           
        }

        return gamesData;

        
    }

    internal static class Part1 {

        public static int CheckIfPossible(string rawText, ExtractionData maxAvailableCubes) {

            IReadOnlyList<GameData> gamesData = GetGamesData(rawText);

            int sum = gamesData
                .Where(gameData => 
                    !gameData.ExtractionData.Any(
                        extractionData => extractionData.Red > maxAvailableCubes.Red || extractionData.Green > maxAvailableCubes.Green || extractionData.Blue > maxAvailableCubes.Blue
                        )
                    )
                .Sum(gameData => gameData.Id);

            return sum;
        }
    
    }
}