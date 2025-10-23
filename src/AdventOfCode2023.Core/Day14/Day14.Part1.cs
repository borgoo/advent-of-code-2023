namespace AdventOfCode2023.Core.Day14;

internal static partial class Day14 {

    internal abstract class PartShared {

        protected const char _empty = '.';
        protected const char _inamovable = '#';
        protected const char _roundRock = 'O'; 

        protected static int TiltToNorth(char[,] grid, int l) {

            int sum = 0;
            for(int i = 0; i < l; i++) {

                for(int j = 0; j < l; j++) {

                    if(grid[i,j] != _roundRock) continue;

                    int destX = i;
                    while(destX -1 >= 0 && grid[destX -1, j] == _empty) {
                        destX--;
                    }

                    if(destX != i) grid[i, j] = _empty;             

                    grid[destX, j] = _roundRock;
                    sum += l - destX;

                    
                }
            }

            return sum;


        }


    }

    internal class Part1 : PartShared {

        internal static int GetTotalLoad(string rawText) {

            var (l, grid) = DayRawTextFormatter.ToRectangularArray<char>(rawText);
            int sum = TiltToNorth(grid, l);
          
            return sum;

        }
    }
}