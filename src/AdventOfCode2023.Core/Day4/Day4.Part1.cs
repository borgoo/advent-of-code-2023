namespace AdventOfCode2023.Core.Day4;

internal static partial class Day4 {

    private static int GetNumOfWinningNumbersPossessed(string line) {

        string tmp = line[(line.IndexOf(": ")+2)..];
        string[] numbers = tmp.Split(" | ");
        HashSet<int> winningNumbers = [.. numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x))];
        HashSet<int> numbersIHave = [.. numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x))];       

        int c = numbersIHave.Intersect(winningNumbers).Count();
        return c;
    }

    private static bool IsWinningScratchCard(int c) {
        return c > 0;
    }

    internal static class Part1 {


        internal static double GetColorfulCardPoints(string rawText) {
            
            double sum = 0;
            string[] lines = rawText.Split(Environment.NewLine);
            foreach(string line in lines) {
              
                int c = GetNumOfWinningNumbersPossessed(line);
                if(!IsWinningScratchCard(c)) continue;
                sum += Math.Pow(2, c -1);              
            }

            return sum;
        }
    }
}