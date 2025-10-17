using System.Text;

namespace AdventOfCode2023.Core.Day9;

internal static partial class Day9 {

    internal class Part2 {

        private static long ExtrapolateValueThatComesBefore(Dictionary<string, (string name, long[] values)> cache, string currRecord, long[] currRecordValues) {
            
            if(currRecordValues.All(value => value == 0)) return 0;
            
            if(cache.ContainsKey(currRecord)) {
                return cache[currRecord].values[0] - ExtrapolateValueThatComesBefore(cache, cache[currRecord].name, cache[currRecord].values);
            }

            long[] newLineValues = new long[currRecordValues.Length -1];
            StringBuilder sb = new();
            for(int i = 1; i < currRecordValues.Length; i++) {
                newLineValues[i-1] = currRecordValues[i] - currRecordValues[i-1];
                sb.Append(newLineValues[i-1]).Append(' ');
            }
            string newLineName = sb.ToString().TrimEnd();

            cache.Add(currRecord, (newLineName, newLineValues));
            return newLineValues[0] - ExtrapolateValueThatComesBefore(cache, newLineName, newLineValues);

        }

        internal static long GetSumOfExtrapolatedPreviousValues(string rawText) {
            
            string[] lines = rawText.Split(Environment.NewLine);
            IEnumerable<(string name, long[] values)> reports = lines.Select(line => 
                                                                             ( name: line, 
                                                                               values: line.Split(' ').Select(long.Parse).ToArray()
                                                                             )
                                                                            );
            Dictionary<string, (string name, long[] values)> cache = [];
            long result = 0;
            foreach(var (name, values) in reports) {

                result += values[0] - ExtrapolateValueThatComesBefore(cache, name, values);

            }

            return result;

        }
    }
}