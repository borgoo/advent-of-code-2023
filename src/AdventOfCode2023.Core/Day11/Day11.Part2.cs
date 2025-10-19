namespace AdventOfCode2023.Core.Day11;

internal static partial class Day11 {

    internal class Part2(int expansionFactor = 1000000) : PartShared {

        private readonly int _toBeAddedDueToExpansionFactor = expansionFactor - 1;

        internal override long GetSumOfMinPathsBetweenGalaxies(string rawText) {
            return GetSumOfMinPathsBetweenGalaxies(rawText, _toBeAddedDueToExpansionFactor);
        }
    }
}