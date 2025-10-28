namespace AdventOfCode2023.Core.Day17;

internal static partial class Day17 {

    internal abstract class PartShared {

        protected abstract int MaxStraightLength {get; init;}
        protected virtual int MinStraightLength {get; init;} = 1;

        protected static readonly Dictionary<char, List<char>> _possibleMoves = new() {
            {'>', ['v', '^', '>']},
            {'<', ['v', '^', '<']},
            {'^', ['>', '<', '^']},
            {'v', ['>', '<', 'v']},
        };

        protected static readonly Dictionary<char, (int dx, int dy)> _directions = new() {
            {'>', (0,1)},
            {'<', (0, -1)},
            {'^', (-1, 0)},
            {'v', (1, 0)},
        };

        protected static readonly (int x, int y) _startingPosition = (0, 0);

        
        protected record NodeStatus(int X, int Y, int HeatLoss, char Direction, int DoneSteps){
            internal (int x, int y, char direction, int doneSteps) GetKey() => (X, Y, Direction, DoneSteps);
        }

        
        private int GetMinHeatLoss(string[] lines) {
            int rows = lines.Length;
            int cols = lines[0].Length;
            (int x, int y) endPosition = (rows - 1, cols - 1);
            Dictionary<(int x, int y, char direction, int doneSteps), int> mins = [];

            PriorityQueue<NodeStatus, int> queue = new();
            int startHeat = 0;
            NodeStatus startE = new(_startingPosition.x, _startingPosition.y, startHeat, '>', 0);
            NodeStatus startS = new(_startingPosition.x, _startingPosition.y, startHeat, 'v', 0);
            mins.Add(startE.GetKey(), startHeat);
            queue.Enqueue(startE, startE.HeatLoss);
            queue.Enqueue(startS, startS.HeatLoss);

            int result = int.MaxValue;     
            while(queue.Count > 0) {
                int numNodes = queue.Count;

                for(int i = 0; i < numNodes; i++) {

                    NodeStatus currentNode = queue.Dequeue();
                    bool currentCanSteer = currentNode.DoneSteps >= MinStraightLength;

                    foreach(char nextDirection in _possibleMoves[currentNode.Direction]) {

                        if(!currentCanSteer && nextDirection != currentNode.Direction) continue;

                     

                        int nextDoneSteps = currentNode.DoneSteps +1;

                        if(nextDirection != currentNode.Direction) nextDoneSteps = 1;

                        if(nextDoneSteps > MaxStraightLength) continue;



                        (int dx, int dy) = _directions[nextDirection];
                        int nextX = currentNode.X + dx;
                        int nextY = currentNode.Y + dy;
                        if(nextX < 0 || nextX >= rows || nextY < 0 || nextY >= cols) continue;
                        int nextHeatLoss = currentNode.HeatLoss + (lines[nextX][nextY] - '0');
                        if(nextHeatLoss >= result) break;

                        NodeStatus nextNode = new(nextX, nextY, nextHeatLoss, nextDirection, nextDoneSteps);
                        if(mins.ContainsKey(nextNode.GetKey())){
                            if( mins[nextNode.GetKey()] <= nextHeatLoss) continue;                            
                        }
                        mins[nextNode.GetKey()] = nextHeatLoss;                    

                        if(nextX == endPosition.x && nextY == endPosition.y) {
                            if(nextDoneSteps < MinStraightLength) continue;
                            result = Math.Min(result, nextHeatLoss);
                            continue;
                        }

                        queue.Enqueue(nextNode, nextNode.HeatLoss);
                       
                    }                   
                    
                }
                
            }  

            return result;

        }


        internal int GetLeastHeatLoss(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            int result = GetMinHeatLoss(lines);
            return result;

        }


    }

    internal class Part1 : PartShared {
        protected override int MaxStraightLength {get; init;} = 3;

    }
}