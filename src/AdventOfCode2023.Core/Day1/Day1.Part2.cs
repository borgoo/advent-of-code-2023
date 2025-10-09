namespace AdventOfCode2023.Core.Day1;

internal static partial class Day1 {

    internal class Part2 {
        private const int _noValue = -1;
        private static readonly Trie _spelledNumbersTrie = new();


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

                var (isSpelledNumber, value, newLeft) = ProcessSpelledNumber(line, left);
                if(isSpelledNumber) {
                    tenValue = value;
                    left = newLeft;
                    break;
                }
                
                left++;
            }

            while(right >= left) {
                
                if(char.IsDigit(line[right])) {
                    unitValue = line[right] - '0';
                    break;
                }
                
                var (isSpelledNumber, value, _) = ProcessSpelledNumber(line, right);
                if(isSpelledNumber) {
                    unitValue = value;
                    break;
                }
                right--;
            }

            if(unitValue == _noValue) unitValue = tenValue;

            return tenValue * 10 + unitValue;
        }
        

        private static (bool isSpelledNumber, int value, int newLeft) ProcessSpelledNumber(string line, int left) {

            TrieNode curr = _spelledNumbersTrie.Root;

            for(int i = left; i < line.Length; i++) {
                char c = line[i];
                if(!curr.Children.ContainsKey(c)) return (false, 0, left);
                curr = curr.Children[c];
                if(curr.EndOfWord) {
                    int value = curr.NumericalValue ?? throw new NullReferenceException();
                    return (true, value, i);
                }
            }

            return (false, 0, left);
        }

    }
}