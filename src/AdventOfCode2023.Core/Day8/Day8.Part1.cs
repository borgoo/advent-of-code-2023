namespace AdventOfCode2023.Core.Day8;

internal static partial class Day8 {

    internal class Part1 {
        
        private const string _start = "AAA";
        private const string _end = "ZZZ";

        internal static int GetNumOfSteps(string rawText) {
            
            string[] lines = rawText.Split(Environment.NewLine);
            string instructions = lines[0];
            int numOfInstructions = instructions.Length;
            Dictionary<string, (string Left, string Right)> instructionsMap = [];
            for(int i = 2; i < lines.Length; i++) {
                string line = lines[i].Trim();
                string key = line[..3];
                string left = line[7..10];
                string right = line[12..15];
                instructionsMap.Add(key, (left, right));                
            }

            string current = _start;
            int step = 0;
            while(current != _end) {
                char cmd = instructions[step % numOfInstructions];
                if(cmd == 'L') current = instructionsMap[current].Left;
                else current = instructionsMap[current].Right;
                step++;
            }

            return step;

        }
            

    }
}