namespace AdventOfCode2023.Core.Day8;

internal static partial class Day8 {

    internal class Part2 {

        private const char _startChar = 'A';
        private const char _endChar = 'Z';

        internal static long GetNumOfSteps(string rawText) {

            Queue<string> nodes = [];
            HashSet<string> endingNodes = [];
            List<int> endsAreReachedAtSteps = [];

            string[] lines = rawText.Split(Environment.NewLine);
            string instructions = lines[0];
            int numOfInstructions = instructions.Length;
            Dictionary<string, (string Left, string Right)> instructionsMap = [];
            for(int i = 2; i < lines.Length; i++) {
                string line = lines[i].Trim();
                string key = line[..3];
                if(key[^1] == _startChar) nodes.Enqueue(key);
                else if(key[^1] == _endChar) endingNodes.Add(key);
                string left = line[7..10];
                string right = line[12..15];
                instructionsMap.Add(key, (left, right));                
            }

            HashSet<(string, int)> seen = [];
            long step = 0;
            while(nodes.Count > 0) {

                int instructionPtr = (int)(step % numOfInstructions);
                char cmd = instructions[instructionPtr];
                int levelNumNodes = nodes.Count;

                for(int i = 0, endNodesFound = 0; i < levelNumNodes; i++) {
                    string currentNode = nodes.Dequeue();

                    if(seen.Contains((currentNode, instructionPtr))) continue;
                    seen.Add((currentNode, instructionPtr));

                    string nextNode;
                    if(cmd == 'L') nextNode = instructionsMap[currentNode].Left;
                    else nextNode = instructionsMap[currentNode].Right;

                    if(endingNodes.Contains(nextNode)) {
                        endNodesFound++;
                        endsAreReachedAtSteps.Add((int)(step + 1));
                    }

                    nodes.Enqueue(nextNode);
                }

                step++;

            }

            return MathUtils.LCM(endsAreReachedAtSteps);
        }
    }
}