namespace AdventOfCode2023.Core;

internal static class GridUtils {

    /// <summary>
    /// In place 90° clockwise rotation of a square grid.
    /// </summary>
    /// <typeparam name="T">The type of the grid elements.</typeparam>
    /// <param name="grid">The grid to rotate.</param>
    /// <param name="l">The length of the grid sides.</param>
    internal static void Rotate90DegreesClockwise<T>(T[,] grid, int l) 
        where T : notnull {

        for(int layer = 0; layer < l / 2; layer++) {
            int first = layer;
            int last = l - 1 - layer;
            
            for(int i = first; i < last; i++) {
                int offset = i - first;
                T top = grid[first, i];
                grid[first, i] = grid[last - offset, first];
                grid[last - offset, first] = grid[last, last - offset];
                grid[last, last - offset] = grid[i, last];
                grid[i, last] = top;
            }
        }

    }

    /// <summary>
    /// Return a new 90° clockwise rotated grid.
    /// </summary>
    /// <typeparam name="T">The type of the grid elements.</typeparam>
    /// <param name="grid">The grid to rotate.</param>
    /// <param name="rows">The number of rows in the grid.</param>
    /// <param name="cols">The number of columns in the grid.</param>
    /// <returns>The 90° clockwise rotated grid.</returns>
    internal static T[][] Rotate90DegreesClockwise<T>(T[][] grid, int rows, int cols) 
        where T : notnull {

        T[][] rotated = new T[cols][];
        for(int i = 0; i < cols; i++) {
            rotated[i] = new T[rows];
        }
        
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                rotated[j][rows - 1 - i] = grid[i][j];
            }
        }
        
        return rotated;
    }
}