namespace AdventOfCode2023.Core.Day15;

internal static partial class Day15 {

    internal class Part2 : PartShared {

        private const int _hashMaxValue = 256;
        private const char _assignOperator = '=';
        private const char _removeOperator = '-';


        private static void AssignToBox(Dictionary<string, (int lensFocusLength, int order)>[] boxes, string cmd, int order) {

            string[] parts = cmd.Split(_assignOperator, StringSplitOptions.RemoveEmptyEntries);
            bool isAssignOperation = parts.Length == 2;
            if(!isAssignOperation) {
                parts = cmd.Split(_removeOperator, StringSplitOptions.RemoveEmptyEntries);
            }
            string lensName = parts[0];
            int hashValue = GetHashValue(lensName);

            if(boxes[hashValue] is null) boxes[hashValue] = [];

            if(isAssignOperation) {
                int newFocusLengthValue = int.Parse(parts[1]);
                if(boxes[hashValue].ContainsKey(lensName)) {
                    int oldOrder = boxes[hashValue][lensName].order;
                    boxes[hashValue][lensName] = (newFocusLengthValue, oldOrder);
                    return;
                }

                boxes[hashValue].Add(lensName, (newFocusLengthValue, order));
                return;
            }

            //is removing operation
            if(boxes[hashValue].ContainsKey(lensName)) {
                boxes[hashValue].Remove(lensName);
                return;
            }
         
            return;
            
        }

        private static int CalculateSumOfFocusingPower(Dictionary<string, (int lensFocusLength, int order)>[] boxes) {

            int sum = 0;
            for(int  box = 0; box < _hashMaxValue; box++) {

                if(boxes[box] is null || boxes[box].Count == 0) continue;

                IEnumerable<(int lensFocusLength, int order)> allValues = boxes[box].Values.OrderBy(x => x.order);
                int slot = 1;
                foreach(var (lensFocusLength, _) in allValues) {
                    sum += (box +1) * slot * lensFocusLength;
                    slot++;
                }

            }

            return sum;
        }

        internal static int GetTotalFocusingPower(string rawText) {

            Dictionary<string, (int lensFocusLength, int order)>[] boxes = new Dictionary<string, (int lensFocusLength, int order)>[_hashMaxValue];

            var cmds = rawText.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            for(int currLens = 0; currLens < cmds.Length; currLens++) {
                AssignToBox(boxes, cmds[currLens], currLens);
            }

            int sum = CalculateSumOfFocusingPower(boxes);
            return sum;
        }
    }
}