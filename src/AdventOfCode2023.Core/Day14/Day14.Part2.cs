using System.Text;

namespace AdventOfCode2023.Core.Day14;

internal static partial class Day14 {

    internal class Part2 : PartShared {

        private const int _numOfCycles = 1000000000;
        private const int _numOfTilts = 4; // 4 directions: north, west, south, east -> rotate 4 times the grid and move north the rocks

        private readonly Dictionary<string, string> _cache = [];


        private static int GetSumOfNorthLoad(string gridAsTxt) {
            string[] lines = gridAsTxt.Split(Environment.NewLine);
            int l = lines.Length;
            int sum = 0;
            for(int i = 0; i < l; i++) {
                for(int j = 0; j < l; j++) {
                    if(lines[i][j] == _roundRock) sum += l - i;
                }
            }
            return sum;
        }

        private static string GridToString(char[,] grid, int l) {
            StringBuilder sb = new();

            for(int i = 0; i < l; i++) {
                for(int j = 0; j < l; j++) {
                    sb.Append(grid[i, j]);
                }
                if(i != l - 1) sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        private static string DoATiltingCycle(string gridAsTxt) {

            (int l, char[,] grid) = DayRawTextFormatter.ToRectangularArray<char>(gridAsTxt);
            int currTilt = 0;
            do {
                TiltToNorth(grid, l);
                currTilt++;
                GridUtils.Rotate90DegreesClockwise(grid, l);

            }while(currTilt < _numOfTilts);

            string resultingGrid = GridToString(grid, l);
            return resultingGrid;

        }

        private int GetLoopLength(string target) {

            string current = target;
            int length = 0;
            do {
                current = _cache[current];
                length++;
            }while(current != target);

            return length;            

        }

        private string HandleLoop(string gridAsTxt, int currCycle, int numOfCycles) {

            int loopLength = GetLoopLength(gridAsTxt);
            int toDo = (numOfCycles - currCycle) % loopLength;
            for(int i = 0; i < toDo; i++) {
                gridAsTxt =  DoATiltingCycle(gridAsTxt);
            }
            return gridAsTxt;

        }

 
        internal int GetTotalLoad(string rawText, int numOfCycles = _numOfCycles)
        {
            string gridAsTxt = rawText;
            for(int i = 0; i < numOfCycles; i++) {

                bool loopFound = _cache.ContainsKey(gridAsTxt);
                if(!loopFound) {
                    _cache.Add(gridAsTxt, DoATiltingCycle(gridAsTxt));
                    gridAsTxt = _cache[gridAsTxt];
                    continue;
                }

                gridAsTxt = HandleLoop(gridAsTxt, i, numOfCycles);
                break;
            }
            return GetSumOfNorthLoad(gridAsTxt);
        }
    }
}