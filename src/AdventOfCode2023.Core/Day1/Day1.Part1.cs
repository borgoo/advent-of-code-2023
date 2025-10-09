namespace AdventOfCode2023.Core.Day1;

internal static partial class Day1 {

    internal static class Part1 {
        
        private const int _noValue = -1;

        internal static long SumAllCalibrationValues(string rawText) {

            string[] lines = rawText.Split('\n');
            return lines.Sum(ExtractCalibrationValue);
        }

        private static int ExtractCalibrationValue(string line) {
            int left = 0, right = line.Length - 1;
            int tenValue = _noValue, unitValue = _noValue;

            while(left < line.Length ) {
                if(char.IsDigit(line[left])) {
                    tenValue = line[left] - '0';
                    break;
                }
                left++;
            }

            while(right > left) {
                if(char.IsDigit(line[right])) {
                    unitValue = line[right] - '0';
                    break;
                }
                right--;
            }

            if(unitValue == _noValue) unitValue = tenValue;

            return tenValue * 10 + unitValue;
        }

    }
}