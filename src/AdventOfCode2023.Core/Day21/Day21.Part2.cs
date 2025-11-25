using System.Text;

namespace AdventOfCode2023.Core.Day21;

internal static partial class Day21
{


    internal class Part2 : PartShared
    {

        internal static long CountDistinctGardenPlotsOnInfiniteGrid(string rawText, int neededSteps)
        {

            bool lastStepIsEven = neededSteps % 2 == 0;

            string[] lines = rawText.Split(Environment.NewLine);
            int n = lines.Length;
            int m = lines[0].Length;
            (int x, int y)? startingPoint = null;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (lines[i][j] == _start)
                    {
                        startingPoint = (i, j);
                        break;
                    }
                }
            }

            _ = startingPoint ?? throw new NullReferenceException("Starting point not found");

            Queue<(int x, int y)> queue = new();
            HashSet<(int x, int y)> seen = [];
            queue.Enqueue(startingPoint.Value);
            seen.Add(startingPoint.Value);

            int nextStep = 1;
            HashSet<(int x, int y)> resultingPositions = [];
            if (lastStepIsEven) resultingPositions.Add(startingPoint.Value);
            while (queue.Count > 0 && nextStep <= neededSteps)
            {

                int num = queue.Count;
                for (int i = 0; i < num; i++)
                {

                    (int x, int y) = queue.Dequeue();
                    bool mustBeAddedToResults = lastStepIsEven ? (nextStep % 2 == 0) : (nextStep % 2 != 0);
                    foreach ((int dx, int dy) in _directions)
                    {
                        int newX = x + dx;
                        int newY = y + dy;

                        int modY = newY % m;
                        if (newY < 0 && modY != 0) modY += m;
                        int modX = newX % n;
                        if (newX< 0 && modX != 0) modX += n;

                        if (lines[modX][modY] == _rock) continue;
                        if (mustBeAddedToResults) resultingPositions.Add((newX, newY));

                        if (seen.Contains((newX, newY))) continue;
                        seen.Add((newX, newY));

                        queue.Enqueue((newX, newY));
                    }
                }
                nextStep++;

            }

            return resultingPositions.Count;
        }

        internal static long TailorMadeSolution(string rawText)
        {

            /***
             * From a reddid hint:
             * steps = num * inputLength + startingPositionOffset (len/2) ->
             * 26501365 = 202300 * 131 + 65
             * Using Day9 solution , starting from the first 4 values of i * 131 + 65, I can predict the next ones
             */

            const int minI = 4; //Or Day9.Part1 will not work
            const int neededSteps = 202300;

            Queue<long> sequence = new();
            // intialize the sequence with first 4 known values
            for(int i = 0; i < minI; i++)
            {
                long tmp = CountDistinctGardenPlotsOnInfiniteGrid(rawText, (i * 131) + 65);
                sequence.Enqueue(tmp);
            }

            long result = 0;
            for (int i = minI; i <= neededSteps; i++)
            {
                string currSequence = string.Join(" ", sequence);
                result = Day9.Day9.Part1.GetSumOfExtrapolatedValues(currSequence);
                sequence.Dequeue();
                sequence.Enqueue(result);
            }


            return result;
        }

    }
}