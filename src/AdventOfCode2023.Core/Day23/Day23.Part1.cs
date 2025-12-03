namespace AdventOfCode2023.Core.Day23; 
 
internal static partial class Day23 { 

    internal abstract class PartShared {

        protected const char _empty = '.';
        protected const char _wall = '#';

        protected static readonly (int dx, int dy)[] _directions = [
            (0,1),
            (0,-1),
            (1,0),
            (-1,0)
        ];

        protected readonly record struct Coordinate(int X, int Y);

      
        internal abstract long GetLongestPath(string rawText);
        
        protected static (Coordinate start, Coordinate end, char[,] grid, int n, int m) ProcessInput(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            Coordinate start = new(0, lines[0].IndexOf(_empty));
            Coordinate end = new(lines.Length - 1, lines[^1].IndexOf(_empty));
            char[,] grid = new char[lines.Length, lines[0].Length];
            for(int i = 0; i < lines.Length; i++) {
                for(int j = 0; j < lines[i].Length; j++) {
                    grid[i, j] = lines[i][j];
                }
            }
            return (start, end, grid, lines.Length, lines[0].Length);

        }
    }
 
    internal class Part1 : PartShared { 
        
        private static readonly Dictionary<char, (int dx, int dy)> _slopes = new() {
            {'>' , (0,1)},
            {'<' , (0,-1)},
            {'v' , (1,0)},
            {'^' , (-1,0)}

        };


        private static int DFS(
            Coordinate curr, 
            Coordinate end, 
            char[,] grid, 
            int currLength,
            int n,
            int m,
            bool[,] visited
        ) {

            char currChar = grid[curr.X,curr.Y];

            (int dx, int dy)[] availableDirections =  _slopes.ContainsKey(currChar) ? [_slopes[currChar]] : _directions;

            int result = -1;
            foreach (var (dx, dy) in availableDirections) {
                Coordinate nextPos = new(curr.X + dx, curr.Y + dy);
                if(nextPos.X < 0 || nextPos.X >= n || nextPos.Y < 0 || nextPos.Y >= m) continue;
                if (nextPos == end) return currLength + 1;
                if(visited[nextPos.X, nextPos.Y]) continue;
                char nextChar = grid[nextPos.X,nextPos.Y];
                if(nextChar == _wall) continue;

                visited[nextPos.X, nextPos.Y] = true;
                int nextLength = currLength + 1;
                int nextLongestPath = DFS(nextPos, end, grid, nextLength, n, m, visited);
                result = Math.Max(result, nextLongestPath);
                visited[nextPos.X, nextPos.Y] = false;
            }

            return result;       


        }


        internal override long GetLongestPath(string rawText) { 
 
            var (start, end, grid, n, m) = ProcessInput(rawText);
            int longest =  DFS(start, end, grid, 0, n ,m, new bool[n,m]);
            return longest;
        }
 


        
    } 
} 
