namespace AdventOfCode2023.Core.Day6;

internal static partial class Day6 {

    internal class Part2 : PartSharing {

        internal static long GetNumOfWinningOutcomes(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            long time = Int64.Parse(
                lines[0][(lines[0].IndexOf(':') + 1)..].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(String.Empty, (acc, curr) => acc + curr)
            );
            long distance = Int64.Parse(
                lines[1][(lines[1].IndexOf(':') + 1)..].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(String.Empty, (acc, curr) => acc + curr)
            );

            return GetNumOfWinningOutcomes(time, distance);
        }
    }
}