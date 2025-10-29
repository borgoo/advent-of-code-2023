namespace AdventOfCode2023.Core.Day18; 
 
internal static partial class Day18 { 
 
    internal class Part2 : PartShared { 
 
        protected override Dictionary<char, (long dx, long dy)> Directions { get; init; } = new() {
            {'0', (0,1)},       //R
            {'2', (0, -1)},     //L
            {'3', (-1, 0)},     //U
            {'1', (1, 0)},      //D
        };

        protected override ( (long x, long y)[] points, long minX, long minY) GetPointsData(string rawText) {

            string[][] data = [..
                rawText.Split(Environment.NewLine)
                .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))];

            int num = data.Length;
            (long x, long y)[] points = new (long x, long y)[num];

            points[0] = _startingPoint;
            long minX = 0, minY = 0;

            for(int i = 1; i < num; i++) {
                string[] parts = data[i-1];
                char direction = parts[2][^2];
                long distance = Convert.ToInt64(parts[2][2..7], 16);

                (long nextX, long nextY) = (  points[i-1].x + Directions[direction].dx * distance, 
                                            points[i-1].y + Directions[direction].dy * distance);
                minX = Math.Min(minX, nextX);
                minY = Math.Min(minY, nextY);
                points[i] = (nextX, nextY);
            }

            return (points, minX, minY);  
        }
    } 
} 
