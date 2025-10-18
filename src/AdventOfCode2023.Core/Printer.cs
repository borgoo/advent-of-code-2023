namespace AdventOfCode2023.Core;

internal static class Printer {

    internal static void PrintMatrix<T>(T[,] matrix) {

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                Console.Write($"{matrix[i, j],3}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }
}