namespace AdventOfCode2023.Core;

internal static class DayRawTextFormatter {

    internal static (int rows, int cols, char[,] matrix) ToMultidimensionalArray(string rawText) {

        string[] lines = rawText.Split(Environment.NewLine);
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] result = new char[rows, cols];
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                result[i, j] = lines[i][j];
            }
        }
        return (rows, cols, result);

    }
}