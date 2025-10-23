namespace AdventOfCode2023.Core.Day13;

internal static partial class Day13 {
    internal class Part2 : PartShared
    {
        protected override bool CheckRowsSpecularity(string[] grid, int index)
        {
            int remainingSmudge = 1;
            int min = index;
            int max = index + 1;
            while(min >= 0 && max < grid.Length) {

                for(int j = 0; j < grid[min].Length; j++) {
                    if(grid[min][j] != grid[max][j]) remainingSmudge--;
                    if(remainingSmudge < 0) return false;
                }
                min--;
                max++;
            }

            return remainingSmudge == 0;
        }
    }
}