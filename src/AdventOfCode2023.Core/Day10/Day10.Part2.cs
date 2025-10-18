namespace AdventOfCode2023.Core.Day10;

internal static partial class Day10 {

    internal class Part2 : PartSharing {

        private static readonly HashSet<char> _verticalPipesThatConnectNorth = ['|', 'L', 'J'];

        private static (int x, int y) ReconstructPathAndReturnFirstChild(
            HashSet<(int x, int y)> path,
            Dictionary<(int x, int y), (int x, int y)> nodeParents, 
            (int x, int y) position
        ) {

            (int x, int y) firstChild = position;
            while(nodeParents.ContainsKey(position)) {
                path.Add(position);
                position = nodeParents[position];  
                if(nodeParents.ContainsKey(position)) firstChild = position;

            }

            return firstChild;
        
        }

        
        private static (HashSet<(int x, int y)> path, (int x, int y)[] firstChildren) GetLoopPath(
            char[,] matrix, 
            int rows,
            int columns,
            (int x, int y) startPosition,
            int[,] depthsMatrix
        ) {

            Dictionary<(int x, int y), (int x, int y)> nodeParents = [];
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

                        if( depthsMatrix[nextX, nextY] == currDistance + 1) {
                            
                            HashSet<(int x, int y)> path = [startPosition];
                            (int x, int y)[] firstChildren =
                            [
                                ReconstructPathAndReturnFirstChild(path, nodeParents, (nextX, nextY)),
                                ReconstructPathAndReturnFirstChild(path, nodeParents, (currX, currY)),
                            ];
                            ReconstructPathAndReturnFirstChild(path, nodeParents, (currX, currY));
                            return (path, firstChildren);
                            
                        }
                        if(depthsMatrix[nextX, nextY] != _neverVisited) continue;

                        nodes.Enqueue((nextX, nextY));
                        nodeParents[(nextX, nextY)] = (currX, currY);
                        depthsMatrix[nextX, nextY] = currDistance + 1;
                    }
                }
                currDistance++;
            }

            throw new InvalidOperationException("No loop found");
        }

        private static char GetFixedStartingPoint(char[,] matrix, (int x, int y)[] firstChildren, (int x, int y) startPosition) {

            (int x, int y) loopBranchA = firstChildren[0];
            (int x, int y) loopBranchB = firstChildren[1];
            char loopBranchAPipe = matrix[loopBranchA.x, loopBranchA.y];
            char loopBranchBPipe = matrix[loopBranchB.x, loopBranchB.y];

            (int dx, int dy) toReachBranchA = _oppositeMoves[(startPosition.x - loopBranchA.x, startPosition.y - loopBranchA.y)];
            (int dx, int dy) toReachBranchB = _oppositeMoves[(startPosition.x - loopBranchB.x, startPosition.y - loopBranchB.y)];
            foreach(var (possiblePipe, moves) in _possibleMoves.Where(e => e.Key != _start)) {
               if(moves.Contains(toReachBranchA) && moves.Contains(toReachBranchB)) return possiblePipe;
            }                

            throw new Exception("Impossible to replace the starting point with a valid pipe.");        
        }



        private static void UpdateMatrixForRayCasting(char[,] matrix, int rows, int cols, HashSet<(int x, int y)> loopPath, (int x, int y)[] firstChildren) { 

            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    if(!loopPath.Contains((i, j))) matrix[i, j] = _empty;
                    if(matrix[i, j] == _start) matrix[i, j] = GetFixedStartingPoint( matrix, firstChildren, (i, j) );
                }
            }

        
        }


        private static bool IsAChangingStatePipe(char pipe) {
            return _verticalPipesThatConnectNorth.Contains(pipe);
        }

        private static int RayCasting(int rows, int cols, HashSet<(int x, int y)> path, (int x, int y)[] firstChildren, char[,] matrix) {
                
            UpdateMatrixForRayCasting(matrix, rows, cols, path, firstChildren);

            //DEBUG Printer.PrintMatrix(matrix);

            const int _inside = 1;
            int insideCount = 0;
            int[,] statusMatrix = new int[rows, cols];
            for(int i = 0; i < rows; i++) {

                bool ouside = true; 
                int j = 0;
                while(j < cols) {

                    bool isChangingStatePipe = IsAChangingStatePipe(matrix[i, j]);
                    if(isChangingStatePipe) {
                        ouside = !ouside;
                        j++;
                        continue;
                    }
                    if(ouside) {
                        j++;
                        continue;
                    }
                    if(path.Contains((i, j))) {
                        j++;
                        continue;
                    }

                    insideCount++;
                    statusMatrix[i, j] = _inside;
                    j++;

                }
               
            }
            
            //DEBUG Printer.PrintMatrix(statusMatrix);

            return insideCount;
                


        }
        
     
        
        internal static int GetNumOfTilesInTheLoop(string rawText) {

            var (matrix, rows, cols, startPosition, depthsMatrix) = ReadInput(rawText);
            var (path, firstChildren) = GetLoopPath(matrix, rows, cols, startPosition, depthsMatrix);
            return RayCasting(rows, cols, path, firstChildren, matrix);
        }
    }
}