namespace AdventOfCode2023.Core.Day5;

internal static partial class Day5 {  

    internal class Part2 : PartSharing {

        private readonly HashSet<(long From, long To, int MapIdx)> _seen = [];

        internal override long GetLowestLocationNumber(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            List<(long From, long To)> seedRanges = [];
            long[] nums = lines[0][(lines[0].IndexOf(' ') + 1) ..].Split(' ').Select(long.Parse).ToArray();
            for(int i = 0; i < nums.Length; i+=2) {
                seedRanges.Add((nums[i], nums[i] + nums[i+1] -1));
            }


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

                _sortedMaps[mapIndex].Sort((a, b) => a.From.CompareTo(b.From));
            }
            
            long min = long.MaxValue;
            foreach(var (From, To) in seedRanges) {
                FollowTheChain(ref min, From, To);
            }


            return min;


            
        }

        private void FollowTheChain(ref long min, long from, long to, int mapIdx = 0) {

            var seenKey = (from, to, mapIdx);
            if(_seen.Contains(seenKey)) return;
            _seen.Add(seenKey);

            if(mapIdx == _sortedMaps.Length) {
                min = Math.Min(min, from);
                return;
            }

            if(!_sortedMaps[mapIdx].Any() || to < _sortedMaps[mapIdx].First().From || from > _sortedMaps[mapIdx].Last().To) {
                FollowTheChain(ref min, from, to, mapIdx + 1);
                return;
            }

            //cut from-to into pieces based on the intervals in the map
            foreach(var mapInterval in _sortedMaps[mapIdx]) {
                if(mapInterval.To < from) continue;
                if(mapInterval.From > to) break;

                //mapInterval completely includes from-to
                if(mapInterval.From <= from && mapInterval.To >= to) {
                    long newFrom = mapInterval.ResultAfterMapping(from);
                    long newTo = mapInterval.ResultAfterMapping(to);
                    FollowTheChain(ref min, newFrom, newTo, mapIdx + 1);
                    return;
                } 

             
                //mapInterval starts before from-to
                if(mapInterval.From <= from && mapInterval.To < to) {
                    long newFrom = mapInterval.ResultAfterMapping(from);
                    long newTo = mapInterval.ResultAfterMapping(mapInterval.To);
                    //mapped from-to
                    if(newFrom <= newTo) FollowTheChain(ref min, newFrom, newTo, mapIdx + 1);
                    //remaining from-to remains the same and should be processed in the same map
                    long remainingFrom = mapInterval.To + 1;
                    long remainingTo = to;
                    FollowTheChain(ref min, remainingFrom, remainingTo, mapIdx);
                    return;
                }

                //mapInterval ends after from-to
                if(mapInterval.From > from && mapInterval.To >= to) {
                    long newFrom = mapInterval.ResultAfterMapping(mapInterval.From);
                    long newTo = mapInterval.ResultAfterMapping(to);
                    //mapped from-to
                    FollowTheChain(ref min, newFrom, newTo, mapIdx + 1);
                    //remaining from-to remains the same and should be processed in the same map
                    long remainingFrom = from;
                    long remainingTo = mapInterval.From - 1;
                    if(remainingFrom <= remainingTo) FollowTheChain(ref min, remainingFrom, remainingTo, mapIdx);
                    return;
                }

            }

            FollowTheChain(ref min, from, to, mapIdx + 1);
        }
    }
}