using System.Text;
namespace AdventOfCode2023.Core.Day12;

internal static partial class Day12 {
    
    internal class Part2 : PartShared {      

        private const int _foldedTimes = 5;
      
        internal override long GetSumOfAllPossibleArrangements(string text) {
            string[] lines = text.Split(Environment.NewLine);
            long sum = 0;
            foreach(string line in lines) {
                if(!line.Contains(_unknownCharacter)) throw new InvalidOperationException($"Line does not contain unknown character {line}");
                string[] data = line.Split(' ');
                StringBuilder sb = new();
                for(int i = 0; i < _foldedTimes; i++) {
                    sb.Append(data[0]);
                    if( i != _foldedTimes - 1) sb.Append(_unknownCharacter);
                }
                string completeLine = sb.ToString();
                
                int[] tmpGroupsData = [.. data[1].Split(',').Select(int.Parse)];
                int[] groupsData = new int[_foldedTimes * tmpGroupsData.Length];
                for(int i = 0; i < _foldedTimes * tmpGroupsData.Length; i++) {
                    groupsData[i] = tmpGroupsData[i % tmpGroupsData.Length];
                }

                sum += GetAllPossibleArrangements(completeLine, groupsData);
            }
            return sum;
        }
    }
}
