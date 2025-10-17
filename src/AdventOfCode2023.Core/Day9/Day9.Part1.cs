using System.Text;

namespace AdventOfCode2023.Core.Day9;

internal static partial class Day9 {

    internal class Part1 {

        private static long ExtrapolateValueThatComesAfter(Dictionary<string, (string name, long[] values)> cache, long afterLastValue, string currRecord, long[] currRecordValues) {
            
            if(currRecordValues.All(value => value == 0)) return afterLastValue;
            
            if(cache.ContainsKey(currRecord)) {
                afterLastValue += cache[currRecord].values[^1];
                return ExtrapolateValueThatComesAfter(cache, afterLastValue, cache[currRecord].name, cache[currRecord].values);
            }

            long[] newLineValues = new long[currRecordValues.Length -1];
            StringBuilder sb = new();
            for(int i = 1; i < currRecordValues.Length; i++) {
                newLineValues[i-1] = currRecordValues[i] - currRecordValues[i-1];
                sb.Append(newLineValues[i-1]).Append(' ');
            }
            string newLineName = sb.ToString().TrimEnd();

            cache.Add(currRecord, (newLineName, newLineValues));
            afterLastValue += newLineValues[^1];
            return ExtrapolateValueThatComesAfter(cache, afterLastValue, newLineName, newLineValues);            

        }

        internal static long GetSumOfExtrapolatedValues(string rawText) {
            
            string[] lines = rawText.Split(Environment.NewLine);
            IEnumerable<(string name, long[] values)> reports = lines.Select(line => 
                                                                             ( name: line, 
                                                                               values: line.Split(' ').Select(long.Parse).ToArray()
                                                                             )
                                                                            );
            Dictionary<string, (string name, long[] values)> cache = [];
            long result = 0;
            foreach(var (name, values) in reports) {

                long afterLastValue = values[^1];              
                result += ExtrapolateValueThatComesAfter(cache, afterLastValue, name, values);
                
            }

            return result;

        }
    }
}