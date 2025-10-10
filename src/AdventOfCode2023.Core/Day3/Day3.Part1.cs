namespace AdventOfCode2023.Core.Day3;

internal static partial class Day3 {

    private const char _empty = '.';

    internal static class Part1 {

        private static bool IsAPartEnabler(char c) {
            return c != _empty && !char.IsDigit(c);
        }

        private static bool IsAPart(char[,] matrix, int rows, int cols, int digitPosX, int digitPosY) {
            
            if(digitPosX > 0 && IsAPartEnabler(matrix[digitPosX - 1, digitPosY])) return true;
            if(digitPosX > 0 && digitPosY > 0 && IsAPartEnabler(matrix[digitPosX - 1, digitPosY - 1])) return true;
            if(digitPosX > 0 && digitPosY < cols - 1 && IsAPartEnabler(matrix[digitPosX - 1, digitPosY + 1])) return true;
            if(digitPosX < rows - 1 && IsAPartEnabler(matrix[digitPosX + 1, digitPosY])) return true;
            if(digitPosY > 0 && IsAPartEnabler(matrix[digitPosX, digitPosY - 1])) return true;
            if(digitPosY < cols - 1 && IsAPartEnabler(matrix[digitPosX, digitPosY + 1])) return true;
            if(digitPosX < rows - 1 && digitPosY > 0 && IsAPartEnabler(matrix[digitPosX + 1, digitPosY - 1])) return true;
            if(digitPosX < rows - 1 && digitPosY < cols - 1 && IsAPartEnabler(matrix[digitPosX + 1, digitPosY + 1])) return true;
            return false;
        }

        internal static int SumAllPartNumbers(string rawText) {

            (int rows, int cols, char[,] matrix) = DayRawTextFormatter.ToMultidimensionalArray(rawText);

            int sum = 0;
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    if(matrix[i, j] == _empty || !char.IsDigit(matrix[i, j])) continue;

                    int num = 0;
                    bool isAPart = false;
                    do{
                        num = num * 10 + (matrix[i, j] - '0');
                        if(!isAPart) isAPart = IsAPart(matrix, rows, cols, i, j);
                        j++;
                    }while(j < cols && char.IsDigit(matrix[i, j]));

                    if(isAPart) sum += num;
                }
            }
            return sum;
        }
    }
}