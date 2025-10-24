namespace AdventOfCode2023.Core.Day16;

internal static partial class Day16 {       

    internal class Part2 : PartShared {

        internal record Node(int X, int Y, char Beam);

        private static int NavigateGraph(Dictionary<Node, List<Node>> cache, Node currentNode, short[,,] seen) {

            if(!cache.ContainsKey(currentNode)) return 0;
            int x = currentNode.X, y = currentNode.Y;
            char beam = currentNode.Beam;
            if(AlreadySeen(seen, x, y, beam)) return 0;
            seen[x, y, _beamDirectionHashes[beam]] = 1;
            int sum = 1;
            foreach(Node nextNode in cache[currentNode]) {
                sum += NavigateGraph(cache, nextNode, seen);
            }
            return sum;

        }    

         internal static int LaunchTheBeam(Dictionary<Node, List<Node>> cache, string[] lines, int rows, int cols, (int x, int y) start, char startDirection) {
            
            Queue<Node> queue = new();
            short[,,] seen = new short[rows, cols, _beamDirectionHashes.Count];
            
            Node startNode = new(start.x, start.y, startDirection);
            queue.Enqueue(startNode);
            seen[start.x, start.y, _beamDirectionHashes[startDirection]] = 1;
            int sum = 1;

            while(queue.Count > 0) {

                int count = queue.Count;
                for(int i = 0; i < count; i++) {

                    Node currentNode = queue.Dequeue();
                    char currentChar = lines[currentNode.X][currentNode.Y];
                    
                    foreach(char nextChar in _reflectionRules[(currentNode.Beam, currentChar)]) {
                        (int nextX, int nextY) = ( currentNode.X + _beamDirections[nextChar].dx, currentNode.Y + _beamDirections[nextChar].dy );
                        if(nextX < 0 || nextX >= rows || nextY < 0 || nextY >= cols) continue;
                        if(AlreadySeen(seen, nextX, nextY, nextChar)) continue;
                        Node nextNode = new(nextX, nextY, nextChar);
                        queue.Enqueue(nextNode);
                        if(NeverSeenTile(seen, nextX, nextY )) sum++;
                        seen[nextX, nextY, _beamDirectionHashes[nextChar]] = 1;

                        bool isNewPathInCache = cache.ContainsKey(nextNode);
                        if(isNewPathInCache) {
                            sum += NavigateGraph(cache, nextNode, seen);
                            continue;
                        }

                        if(!cache.ContainsKey(currentNode)) cache.Add(currentNode, []);
                        cache[currentNode].Add(nextNode);


                    }
                }
            }

            return sum;
        }



        internal static int GetBestNumberOfEnergizedTiles(string rawText) {
            string[] lines = rawText.Split(Environment.NewLine);
            int rows = lines.Length;
            int cols = lines[0].Length;
            Dictionary<Node, List<Node>> cache = [];

            int max = 0;

            for(int x = 0; x < rows; x++) {

                max = Math.Max(max, LaunchTheBeam( cache, lines, rows, cols, (x, 0), '>'));
                max = Math.Max(max, LaunchTheBeam( cache, lines, rows, cols, (x, cols - 1), '<'));
            }
            for(int y = 0; y < cols; y++) {

                max = Math.Max(max, LaunchTheBeam( cache, lines, rows, cols, (0, y), 'v'));
                max = Math.Max(max, LaunchTheBeam( cache, lines, rows, cols, (rows - 1, y), '^'));
            }

            return max;
        }

    }
}