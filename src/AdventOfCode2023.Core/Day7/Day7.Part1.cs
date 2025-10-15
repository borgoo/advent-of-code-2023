namespace AdventOfCode2023.Core.Day7;   

internal static partial class Day7 {

    internal static class Part1 {
      
        // -1 -> first hand is worst, +1 -> second hand is worst
        internal static int HandComparer(Hand a, Hand b) {
            return a.CompareTo(b);          
        }

        internal static long CalculateTotalWinnings(string rawText) {

            IEnumerable<Hand> hands = rawText.Split(Environment.NewLine).Select(line => new Hand(line.Split(' ')[0], int.Parse(line.Split(' ')[1])));

            var customComparer = Comparer<Hand>.Create(HandComparer);
            PriorityQueue<Hand, Hand> priorityQueue = new(customComparer);

            foreach(Hand hand in hands) {
                priorityQueue.Enqueue(hand, hand);
            }

            long totalWinnings = 0;       
            for(int rank = 1; priorityQueue.Count > 0; rank++) {
                Hand hand = priorityQueue.Dequeue();
                totalWinnings += rank * hand.Bid;
            }
            return totalWinnings;
        }
    }
}