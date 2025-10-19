namespace AdventOfCode2023.Core.Day11;

internal static partial class Day11 {

    internal abstract class PartShared {
        protected const char _galaxy = '#';

        internal abstract long GetSumOfMinPathsBetweenGalaxies(string rawText);
        protected static long GetSumOfMinPathsBetweenGalaxies(string rawText, int toBeAddedDueToExpansionFactor) {

            string[] lines = rawText.Split(Environment.NewLine);
            HashSet<int> rowsInExpansion = [];
            HashSet<int> columnsInExpansion = [.. Enumerable.Range(0, lines[0].Length)];
            HashSet<(int x, int y)> galaxies = [];

            for(int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                bool foundAGalxyInRow = false;
                for(int j = 0; j < line.Length; j++) {
                    if(line[j] == _galaxy) {
                        foundAGalxyInRow = true;
                        columnsInExpansion.Remove(j);
                        galaxies.Add((i, j));
                    }
                }

                if(!foundAGalxyInRow) rowsInExpansion.Add(i);
            }

            long result = 0;
            var pairList = galaxies.ToArray();
            for(int i = 0; i < pairList.Length -1; i++) {

                (int x, int y) a = pairList[i];

                for(int j = i + 1; j < pairList.Length; j++) {

                    (int x, int y) b = pairList[j];
                    long rowDistance = Math.Abs(a.x - b.x);
                    long expansionRowDistance = rowsInExpansion.Count(r => r >= Math.Min(a.x, b.x) && r <= Math.Max(a.x, b.x)); 
                    long columnDistance = Math.Abs(a.y - b.y);
                    long expansionColumnDistance = columnsInExpansion.Count(c => c >= Math.Min(a.y, b.y) && c <= Math.Max(a.y, b.y)); 

                    long distance = rowDistance + (expansionRowDistance * toBeAddedDueToExpansionFactor) + columnDistance + (expansionColumnDistance * toBeAddedDueToExpansionFactor);
                    result += distance;
                }
            }

            return result;
                

               
        }
    }

    internal class Part1 : PartShared {

        private const int _expansionFactor = 2;

        internal override long GetSumOfMinPathsBetweenGalaxies(string rawText) {
            return GetSumOfMinPathsBetweenGalaxies(rawText, _expansionFactor -1);
        }
    }
}