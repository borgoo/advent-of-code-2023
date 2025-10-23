using System.Text;

namespace AdventOfCode2023.Core.Day13;

internal static partial class Day13 {

    internal abstract class PartShared {

        private const int _rowsMultiplier = 100;

        internal static string[] ColumnsToRows(string[] grid, int rows, int cols) {

            string[] rotatedGrid = new string[cols];
            for(int i = 0; i < cols; i++) {

                StringBuilder sb = new();
                for(int j = 0; j < rows; j++) {
                    sb.Append(grid[j][i]);
                }
                rotatedGrid[i] = sb.ToString();
            }
            return rotatedGrid;
        }

        protected abstract bool CheckRowsSpecularity(string[] grid, int index);


        private int GetSpecularRowsAndColsSums(string[] grid, int rowsMultiplier) {
            
            int rows = grid.Length;
            int cols = grid[0].Length;
            for(int i = 0; i < rows -1; i++) {
                bool isRowSpecular = CheckRowsSpecularity(grid, i);
                if(isRowSpecular) return (i + 1) * rowsMultiplier;
            }

            string[] rotatedGrid = ColumnsToRows(grid, rows, cols);
            rows = rotatedGrid.Length;
            for(int i = 0; i < rows -1; i++) {
                bool isRowSpecular = CheckRowsSpecularity(rotatedGrid, i);
                if(isRowSpecular) return i + 1;
            }

            return 0;
        }

        internal int GetNotesSum(string rawText) {
        
            string[] blocks = rawText.Split(Environment.NewLine + Environment.NewLine);
            int sum = 0;
            foreach(string block in blocks) {

                string[] grid = [..block.Split(Environment.NewLine).Select(line => line.Trim())];

                sum += GetSpecularRowsAndColsSums(grid, _rowsMultiplier);            
                
            }

            return sum;

        }

    }


    internal class Part1 : PartShared {

        protected override bool CheckRowsSpecularity(string[] grid, int index)
        {
            int min = index;
            int max = index + 1;
            while(min >= 0 && max < grid.Length) {
                if(!string.Equals(grid[min], grid[max])) return false;
                min--;
                max++;
            }
            return true;
        }
    }
}

        