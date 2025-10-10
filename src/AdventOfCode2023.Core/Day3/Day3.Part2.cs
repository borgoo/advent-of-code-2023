using System.Reflection;

namespace AdventOfCode2023.Core.Day3;

internal static partial class Day3 {

    internal static class Part2 {

        private const char _gear = '*';
        private const int _exactNumOfNumbersPerGear = 2;
        private static bool IsAGear(char c) => c == _gear;

        private static void AddSeenGears(HashSet<(int I, int J)> gears, char[,] matrix, int rows, int cols, int i, int j) {

            if(i > 0 && IsAGear(matrix[i - 1, j])) gears.Add((i - 1, j));
            if(i > 0 && j > 0 && IsAGear(matrix[i - 1, j - 1])) gears.Add((i - 1, j - 1));
            if(i > 0 && j < cols - 1 && IsAGear(matrix[i - 1, j + 1])) gears.Add((i - 1, j + 1));
            if(i < rows - 1 && IsAGear(matrix[i + 1, j])) gears.Add((i + 1, j));
            if(j > 0 && IsAGear(matrix[i, j - 1])) gears.Add((i, j - 1));
            if(j < cols - 1 && IsAGear(matrix[i, j + 1])) gears.Add((i, j + 1));
            if(i < rows - 1 && j > 0 && IsAGear(matrix[i + 1, j - 1])) gears.Add((i + 1, j - 1));
            if(i < rows - 1 && j < cols - 1 && IsAGear(matrix[i + 1, j + 1])) gears.Add((i + 1, j + 1));
            
            return;
        }
        
        internal static int FindGearRatio(string rawText) {
            
            (int rows, int cols, char[,] matrix) = DayRawTextFormatter.ToMultidimensionalArray(rawText);

            Dictionary<(int X, int Y), List<int>> gearsAdjacentNumbers = [];
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    if(matrix[i, j] == _empty || !char.IsDigit(matrix[i, j])) continue;

                    int num = 0;
                    HashSet<(int X, int Y)> seenGears = [];
                    do{
                        num = num * 10 + (matrix[i, j] - '0');
                        AddSeenGears(seenGears, matrix, rows, cols, i, j);
                        j++;
                    }while(j < cols && char.IsDigit(matrix[i, j]));

                    foreach( var(I,J) in seenGears) {                        
                        if(!gearsAdjacentNumbers.ContainsKey((I, J))) gearsAdjacentNumbers.Add((I, J), []);
                        gearsAdjacentNumbers[(I, J)].Add(num);
                    }
                }
            }

            return gearsAdjacentNumbers
                    .Values
                    .Where(numbers => numbers.Count == _exactNumOfNumbersPerGear)
                    .Sum(numbers => numbers[0] * numbers[1]);

        }
        
    }
}