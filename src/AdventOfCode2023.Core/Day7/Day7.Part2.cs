namespace AdventOfCode2023.Core.Day7;   

internal static partial class Day7 {

    internal static class Part2 {
      
        // -1 -> first hand is worst, +1 -> second hand is worst
        internal static int HandComparer(HandWithJokers a, HandWithJokers b) {
            return a.CompareTo(b);          
        }

        internal static long CalculateTotalWinnings(string rawText) {

            IEnumerable<HandWithJokers> hands = rawText.Split(Environment.NewLine).Select(line => new HandWithJokers(line.Split(' ')[0], int.Parse(line.Split(' ')[1])));

            var customComparer = Comparer<HandWithJokers>.Create(HandComparer);
            PriorityQueue<HandWithJokers, HandWithJokers> priorityQueue = new(customComparer);

            foreach(HandWithJokers hand in hands) {
                priorityQueue.Enqueue(hand, hand);
            }

            long totalWinnings = 0;       
            for(int rank = 1; priorityQueue.Count > 0; rank++) {
                HandWithJokers hand = priorityQueue.Dequeue();
                totalWinnings += rank * hand.Bid;
            }
            return totalWinnings;
        }
    }
}