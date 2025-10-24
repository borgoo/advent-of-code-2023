namespace AdventOfCode2023.Core.Day16;

internal static partial class Day16 {   

    internal abstract class PartShared {

        
        private const char _empty = '.';
        private readonly static (int dx, int dy) _north = (-1, 0);
        private readonly static (int dx, int dy) _south = (1, 0);
        private readonly static (int dx, int dy) _east = (0, 1);
        private readonly static (int dx, int dy) _west = (0, -1);

        protected readonly static Dictionary<char, (int dx, int dy)> _beamDirections = new() {
            { '>', _east },
            { '<', _west },
            { 'v', _south },
            { '^', _north }
        };
        
        protected readonly static Dictionary<char, short> _beamDirectionHashes = new() {
            { '>', 0 },
            { '<', 1 },
            { 'v', 2 },
            { '^', 3 }
        };

        

        protected readonly static Dictionary<(char, char), char[]> _reflectionRules = new() {

            { ('>', _empty ), new[] { '>', } },
            { ('<', _empty ), new[] { '<',} },
            { ('v', _empty ), new[] { 'v'} },
            { ('^', _empty ), new[] { '^'} },

            { ('>', '|' ), new[] { '^', 'v' } },
            { ('<', '|' ), new[] { '^', 'v' } },
            { ('v', '|' ), new[] { 'v'} },
            { ('^', '|' ), new[] { '^'} },

            { ('>', '-'), new[] { '>' } },
            { ('<', '-'), new[] { '<' } },
            { ('v', '-'), new[] { '<', '>' } },
            { ('^', '-'), new[] { '<', '>' } },

            { ('>', '/' ), new[] { '^' } },
            { ('<', '/' ), new[] { 'v' } },
            { ('v', '/' ), new[] { '<'} },
            { ('^', '/' ), new[] { '>'} },
            
            { ('>', '\\' ), new[] { 'v' } },
            { ('<', '\\' ), new[] { '^' } },
            { ('v', '\\' ), new[] { '>'} },
            { ('^', '\\' ), new[] { '<'} },
        };

        protected static bool NeverSeenTile(short[,,] seen, int x, int y) {
            for(int i = 0; i < seen.GetLength(2); i++) {
                if(seen[x, y, i] != 0) return false;
            }
            return true;
        }

        protected static bool AlreadySeen(short[,,] seen, int x, int y, char beam) {
            return seen[x, y, _beamDirectionHashes[beam]] == 1;
        }

    }
    

    internal class Part1 : PartShared {


        private static readonly ((int x, int y) position, char beam) _start = ((0,0), '>');
      
        private static int LaunchTheBeam(string[] lines, int rows, int cols, (int x, int y) start, char startDirection) {
            
            Queue<(int x, int y, char beam)> queue = new();
            short[,,] seen = new short[rows, cols, _beamDirectionHashes.Count];
            
            queue.Enqueue((start.x, start.y, startDirection));
            seen[start.x, start.y, _beamDirectionHashes[startDirection]] = 1;
            int sum = 1;

            while(queue.Count > 0) {

                int count = queue.Count;
                for(int i = 0; i < count; i++) {

                    (int x, int y, char beam) = queue.Dequeue();
                    char currentChar = lines[x][y];
                    
                    foreach(char nextChar in _reflectionRules[(beam, currentChar)]) {
                        (int nextX, int nextY) = ( x + _beamDirections[nextChar].dx, y + _beamDirections[nextChar].dy );
                        if(nextX < 0 || nextX >= rows || nextY < 0 || nextY >= cols) continue;
                        if(AlreadySeen(seen, nextX, nextY, nextChar)) continue;
                        queue.Enqueue((nextX, nextY, nextChar));
                        if(NeverSeenTile(seen, nextX, nextY )) sum++;
                        seen[nextX, nextY, _beamDirectionHashes[nextChar]] = 1;
                    }
                }
            }

            return sum;
        }


        internal static int GetNumberOfEnergizedTiles(string rawText) {
            string[] lines = rawText.Split(Environment.NewLine);
            int rows = lines.Length;
            int cols = lines[0].Length;

            int sum = LaunchTheBeam(lines, rows, cols, _start.position, _start.beam);

            return sum;
        }

    }
}