namespace AdventOfCode2023.Core.Day23; 

internal static partial class Day23 {

    internal class Part2 : PartShared
    {
       

        private static HashSet<Coordinate> FindJunctions(char[,] grid, int n, int m, Coordinate start, Coordinate end)
        {
            const int minNeighborsToNotBeACorridor = 3;
            HashSet<Coordinate> junctions = [start, end];

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (grid[i, j] == _wall) continue;

                    int neighbors = 0;
                    foreach (var (dx, dy) in _directions)
                    {
                        int nx = i + dx;
                        if(nx < 0 || nx >= n) continue;
                        int ny = j + dy;
                        if(ny < 0 || ny >= m) continue;
                        if(grid[nx, ny] == _wall) continue;
                        neighbors++;
                    }

                    if (neighbors >= minNeighborsToNotBeACorridor) junctions.Add(new Coordinate(i, j));
                }   
            }

            return junctions;
        }

        private static Dictionary<Coordinate, List<(Coordinate neighbor, int distance)>> CompactGridIntoWeightedGraph(
            HashSet<Coordinate> junctions,
            char[,] grid,
            int n,
            int m
        ) {

            Dictionary<Coordinate, List<(Coordinate, int)>> graph = [];

            foreach (Coordinate junction in junctions)
            {
                graph.Add(junction, []);

                Queue<Coordinate> queue = [];
                HashSet<Coordinate> seen = [junction];
                queue.Enqueue(junction);
                int dist = 0;

                while (queue.Count > 0)
                {
                    int level = queue.Count;
                    for(int i = 0; i < level; i++) {

                        Coordinate curr = queue.Dequeue();

                        if (dist > 0 && junctions.Contains(curr))
                        {
                            graph[junction].Add((curr, dist)); // corridor created
                            continue;
                        }

                        foreach (var (dx, dy) in _directions)
                        {
                            int nx = curr.X + dx;
                            if(nx < 0 || nx >= n) continue;
                            int ny = curr.Y + dy;
                            if(ny < 0 || ny >= m) continue;
                            if(grid[nx, ny] == _wall) continue;
                            Coordinate next = new(nx, ny);
                            if(seen.Contains(next)) continue;
                            seen.Add(next);
                            queue.Enqueue(next);
                        }
                    }
                    dist++;

                }
            }

            return graph;
        }

        private static int DFS(
            Coordinate curr,
            Coordinate end,
            Dictionary<Coordinate, List<(Coordinate neighbor, int distance)>> graph,
            int currLength,
            HashSet<Coordinate> seen)
        {

            int maxLength = -1;
            foreach (var (neighbor, distance) in graph[curr])
            {
                if (seen.Contains(neighbor)) continue;

                seen.Add(neighbor);
                int length = neighbor == end ? currLength + distance : DFS(neighbor, end, graph, currLength + distance, seen);
                maxLength = Math.Max(maxLength, length);
                seen.Remove(neighbor);
            }

            return maxLength;
        }

        internal override long GetLongestPath(string rawText)
        {
            var (start, end, grid, n, m) = ProcessInput(rawText);

            HashSet<Coordinate> junctions = FindJunctions(grid, n, m, start, end);

            Dictionary<Coordinate, List<(Coordinate neighbor, int distance)>> graph = CompactGridIntoWeightedGraph(junctions, grid, n, m);

            HashSet<Coordinate> seen = [start];
            int longest = DFS(start, end, graph, 0, seen);

            return longest;
        }
    }
}