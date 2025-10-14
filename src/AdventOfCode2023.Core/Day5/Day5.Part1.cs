namespace AdventOfCode2023.Core.Day5;

internal static partial class Day5 {   

    internal abstract class PartSharing {

        protected record Interval(long From, long To, long Delta) {
            internal long ResultAfterMapping(long input) => input + Delta;
        }
        protected readonly List<Interval>[] _sortedMaps = [
            [], //seed to soil
            [], //soil to fertilizer
            [], //fertilizer to water
            [], //water to light
            [], //light to temperature
            [], //temperature to humidity
            []  //humidity to location
        ];

        protected static bool IsHeader(string line) {
            return line.Contains(':');
        }

        internal abstract long GetLowestLocationNumber(string rawText);

    }
    internal class Part1 : PartSharing {        

        private static IEnumerable<long> GetSeeds(string firstLine) {
            return firstLine[(firstLine.IndexOf(' ') + 1) ..].Split(' ').Select(long.Parse);
        }

        private long FollowTheChain(long key) {

            foreach(var map in _sortedMaps) {

                Interval? func = map.FirstOrDefault(m => m.From <= key && m.To >= key);
                if(func == null) continue;
                key += func.Delta;
            }

            return key;
        }

        internal override long GetLowestLocationNumber(string rawText) {

            
            string[] lines = rawText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<long> seeds = GetSeeds(lines[0]);

            for(int i = 2, mapIndex = 0; i < lines.Length; i++, mapIndex++) {

                while(i < lines.Length && !IsHeader(lines[i])) {

                    long[] tmp = [.. lines[i].Split(' ').Select(long.Parse)];
                    long dest = tmp[0];
                    long source = tmp[1];
                    long range = tmp[2];
                    long delta = dest - source;

                    Interval interval = new(source, source + range -1, delta);
                    _sortedMaps[mapIndex].Add(interval);
                    i++;
                }
            }

            long min = long.MaxValue;
            foreach(long seed in seeds) {
                long val = FollowTheChain(seed);
                min = Math.Min(min, val);
            }

            return min;                  
            

        }
    }
}