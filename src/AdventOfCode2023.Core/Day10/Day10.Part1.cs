namespace AdventOfCode2023.Core.Day10;

internal static partial class Day10 {


    internal abstract class PartSharing {

        protected const char _empty = '.';
        protected const char _start = 'S';
        protected const int _neverVisited = -1;
        protected static readonly (int dx, int dy) _north = (-1,0);
        protected static readonly (int dx, int dy) _south = (1,0);
        protected static readonly (int dx, int dy) _west = (0,-1);
        protected static readonly (int dx, int dy) _east = (0,1);

         protected static readonly Dictionary<char, List<(int dx, int dy)>> _possibleMoves = new() {
            { 'S', [_north, _south, _west, _east] },
            { '|', [_north, _south] },
            { '-', [_east, _west] },
            { 'L', [_north, _east] },
            { 'J', [_north, _west] },
            { '7', [_south, _west] },
            { 'F', [_south, _east] }
        };

        protected static readonly Dictionary<(int dx, int dy), (int dx, int dy)> _oppositeMoves = new() {
            { _north, _south },
            { _south, _north },
            { _west, _east },
            { _east, _west }
        };
        protected static bool AreCompatiblePipes((int dx, int dy) usingMove, char nextPipe) {
            return _possibleMoves[nextPipe].Contains(_oppositeMoves[usingMove]);
        }

        protected static (char[,] matrix, int rows, int cols, (int x, int y) startPosition, int[,] depthsMatrix) ReadInput(string rawText) {
            
            string[] lines = rawText.Split(Environment.NewLine).Select(line => line.Trim()).ToArray();
            int rows = lines.Length;
            int cols = lines[0].Length;
            char[,] matrix = new char[rows, cols];
            int[,] depthsMatrix = new int[rows, cols];
            (int x, int y)? startPosition = null;
            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    char c = lines[i][j];
                    matrix[i, j] = c;
                    depthsMatrix[i, j] = _neverVisited;
                    if(c == _start) startPosition = (i, j);
                }
            } 

            if(startPosition is null) throw new NullReferenceException("No start position found");

            return (matrix, rows, cols, startPosition.Value, depthsMatrix);
        }

    }

    internal class Part1 : PartSharing {  

    private static int ExploreUntilLoopIsFound(
        char[,] matrix, 
        int rows,
        int columns,
        (int x, int y) startPosition,
        int[,] depthsMatrix
    ) {

        Queue<(int x, int y)> nodes = new();
        nodes.Enqueue(startPosition);
        depthsMatrix[startPosition.x, startPosition.y] = 0;

        int currDistance = 0;
        while(nodes.Count > 0) {
            
            int num = nodes.Count;

            for(int i = 0; i < num; i++) {
                var (currX, currY) = nodes.Dequeue();
                char currentPipe = matrix[currX, currY];
                foreach(var (dx, dy) in _possibleMoves[currentPipe]) {
                    int nextX = currX + dx;
                    if(nextX < 0 || nextX >= rows) continue;
                    int nextY = currY + dy;
                    if(nextY < 0 || nextY >= columns) continue;
                    char nextPipe = matrix[nextX, nextY];
                    if(nextPipe == _empty) continue;

                    if(!AreCompatiblePipes((dx,dy),  nextPipe)) continue;

                    if( depthsMatrix[nextX, nextY] == currDistance + 1) return currDistance + 1;
                    if(depthsMatrix[nextX, nextY] != _neverVisited) continue;

                    nodes.Enqueue((nextX, nextY));
                    depthsMatrix[nextX, nextY] = currDistance + 1;
                }
            }
            currDistance++;
        }

        throw new InvalidOperationException("No loop found");
    }


        
        internal static int GetFarthestDistance(string rawText) {

            var (matrix, rows, cols, startPosition, depthsMatrix) = ReadInput(rawText);            

            return ExploreUntilLoopIsFound(matrix, rows, cols, startPosition, depthsMatrix);
        }
    }
}