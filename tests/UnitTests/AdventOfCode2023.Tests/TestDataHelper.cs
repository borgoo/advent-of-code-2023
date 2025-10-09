namespace AdventOfCode2023.Tests;

/// <summary>
/// Helper class for loading test data files.
/// Follows the convention: Day{N}/Day{N}.Part{P}.{DataType}.txt
/// </summary>
internal static class TestDataHelper
{
    /// <summary>
    /// Loads puzzle input for a specific day and part.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="part">The part number (1-2)</param>
    /// <returns>The content of the puzzle input file</returns>
    /// <exception cref="FileNotFoundException">If the input file doesn't exist</exception>
    internal static string LoadPuzzleInput(int day, int part)
    {
        string fileName = $"Day{day}/Day{day}.Part{part}.PuzzleInput.txt";
        return LoadFile(fileName);
    }

    /// <summary>
    /// Loads sample input for a specific day and part.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="part">The part number (1-2)</param>
    /// <returns>The content of the sample input file</returns>
    /// <exception cref="FileNotFoundException">If the input file doesn't exist</exception>
    internal static string LoadSampleInput(int day, int part)
    {
        string fileName = $"Day{day}/Day{day}.Part{part}.SampleInput.txt";
        return LoadFile(fileName);
    }

    /// <summary>
    /// Loads any file relative to the test output directory.
    /// </summary>
    /// <param name="relativePath">Path relative to the test assembly output directory</param>
    /// <returns>The content of the file</returns>
    /// <exception cref="FileNotFoundException">If the file doesn't exist</exception>
    private static string LoadFile(string relativePath)
    {
        if (!File.Exists(relativePath))
        {
            throw new FileNotFoundException(
                $"Test data file not found: {relativePath}. " +
                $"Current directory: {Directory.GetCurrentDirectory()}");
        }

        return File.ReadAllText(relativePath);
    }
}
