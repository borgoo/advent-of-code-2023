namespace AdventOfCode2023.Core;

internal static class DayRawTextFormatter {

    internal static (int l, T[,] matrix) ToRectangularArray<T>(string rawText, bool trim = false) 
        where T : notnull {

        string[] lines = rawText.Split(Environment.NewLine);
        if(trim) lines = [.. lines.Select(line => line.Trim())];
        int l = lines.Length;
        T[,] result = new T[l, l];
        for(int i = 0; i < l; i++) {
            for(int j = 0; j < l; j++) {
                result[i, j] = (T)Convert.ChangeType(lines[i][j], typeof(T));
            }
        }
        return (l, result);

    }

    internal static (int rows, int cols, T[][] matrix) ToBidimensionalArray<T>(string rawText, bool trim = false)
    where T : notnull {
        
        string[] lines = rawText.Split(Environment.NewLine);
        if(trim) lines = [.. lines.Select(line => line.Trim())];
        int rows = lines.Length;
        int cols = lines[0].Length;
        T[][] result = new T[rows][];
        for(int i = 0; i < rows; i++) {
            result[i] = [.. lines[i].Select(c => (T)Convert.ChangeType(c, typeof(T)))];
        }
        return (rows, cols, result);
    }
}