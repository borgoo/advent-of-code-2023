namespace AdventOfCode2023.Core.Day18; 
 
internal static partial class Day18 { 

    internal abstract class PartShared {

        protected abstract ( (long x, long y)[] points, long minX, long minY) GetPointsData(string rawText);
        protected static readonly (long x, long y) _startingPoint = (0, 0);
        protected abstract Dictionary<char, (long dx, long dy)> Directions { get; init; }

        private static long MoveTheOriginAndGetPerimeter((long x, long y)[] points, long minX, long minY) {

            bool moveTheOrigin = minX != 0 || minY != 0;
            long perimeter = 0;

            for(int i = 0; i < points.Length; i++) {

                if(i < points.Length - 1) 
                    perimeter += Math.Abs(points[i].x - points[i + 1].x) + Math.Abs(points[i].y - points[i + 1].y);
                    
                if(moveTheOrigin) points[i] = (points[i].x - minX, points[i].y - minY);

            }

            perimeter += Math.Abs(points[^1].x - points[0].x) + Math.Abs(points[^1].y - points[0].y);


            return perimeter;

        }

        private static double ShoelaceArea((long x, long y)[] points) {
            int n = points.Length;
            double area = 0.0;
            for (int i = 0; i < n - 1; i++) {
                area += points[i].x * points[i + 1].y - points[i + 1].x * points[i].y;
            }
            return Math.Abs(area + points[n - 1].x * points[0].y - points[0].x * points[n - 1].y) / 2.0;
        }

        /// <summary>
        /// Get the total area of the polygon using Pick's theorem.
        /// Pick's theorem (I = A - B/2 + 1) connects:
        /// - A: geometric area
        /// - I: interior lattice points (integer coordinates inside)
        /// - B: bondary lattice points (perimeter)
        /// From that I can obtain the total area = interal points + perimeter => A - B/2 + 1 + B = A + B/2 + 1
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        private static long GetPickTheoremTotalArea(double A, long B) {
            return (long)(A + (double)B / 2 + 1);
        }

        internal long GetArea(string rawText) { 
           
            var(points, minX, minY) = GetPointsData(rawText);
            long perimeter = MoveTheOriginAndGetPerimeter(points, minX, minY);
            double shoelaceGeometricArea = ShoelaceArea(points);   

            return GetPickTheoremTotalArea(shoelaceGeometricArea, perimeter);            

        } 

    }
 
    internal class Part1 : PartShared { 

        protected override Dictionary<char, (long dx, long dy)> Directions { get; init; } = new() {
            {'R', (0,1)},
            {'L', (0, -1)},
            {'U', (-1, 0)},
            {'D', (1, 0)},
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
                char direction = parts[0][0]; 
                long distance = int.Parse(parts[1]); 

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
