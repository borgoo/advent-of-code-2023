namespace AdventOfCode2023.Core.Day21; 
 
internal static partial class Day21 { 

   

    internal abstract class PartShared
    {
        protected const char _rock = '#';
        protected const char _start = 'S';
        protected const char _empty = '.';
        protected static readonly (int x, int y)[] _directions = [
           (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0)
       ];

    }

    internal class Part1 : PartShared { 

    private const int _defaultNeededSteps = 64;   
 
    internal static long CountDistinctGardenPlots(string rawText, int neededSteps = _defaultNeededSteps) { 

        bool lastStepIsEven = neededSteps % 2 == 0;

        string[] lines = rawText.Split(Environment.NewLine);
        int n = lines.Length;
        int m = lines[0].Length;
        (int x, int y)? startingPoint = null;
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < m; j++) {
                if(lines[i][j] == _start) {
                    startingPoint = (i, j);
                    break;
                }
            }
        }

        _= startingPoint ?? throw new NullReferenceException("Starting point not found");

        Queue<(int x, int y)> queue = new();
        HashSet<(int x, int y)> seen = [];
        queue.Enqueue(startingPoint.Value);
        seen.Add(startingPoint.Value);

        int nextStep = 1;
        HashSet<(int x, int y)> resultingPositions = [];
        if(lastStepIsEven) resultingPositions.Add(startingPoint.Value);
        while (queue.Count > 0 && nextStep <= neededSteps) {

            int num = queue.Count;
            for(int i = 0; i < num; i++) {
                    
                (int x, int y) = queue.Dequeue();
                bool mustBeAddedToResults = lastStepIsEven ? (nextStep % 2 == 0) : (nextStep % 2 != 0);
                foreach ((int dx, int dy) in _directions) {
                    int newX = x + dx;
                    int newY = y + dy;
                    if(newX < 0 || newX >= n || newY < 0 || newY >= m) continue;
                    if(lines[newX][newY] == _rock) continue;
                    if(seen.Contains((newX, newY))) continue;
                    seen.Add((newX, newY));

                    queue.Enqueue((newX, newY));
                    if(mustBeAddedToResults) resultingPositions.Add((newX, newY));
                }
            }               
            nextStep++;

        }

        return resultingPositions.Count;
    } 
 
} 
}
