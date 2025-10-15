namespace AdventOfCode2023.Core.Day6;

internal static partial class Day6 {

    internal abstract class PartSharing {

        protected class NegativeDiscriminantException : Exception {}

        /***
        * REMINDER : Accelaration = 1 mm/ms^2 so it can be ignored
        * pt = pressing time (ms)
        * d = distance to be beaten (mm)
        * t = available time (ms)
        * - pt^2 + pt*t - d > 0
        */
        protected static (int Min, int Max) GetParabolaLimits(double t, double d) {

            double discriminant = t*t - 4*d;
            if(discriminant < 0) throw new NegativeDiscriminantException();
            double sqrt = Math.Sqrt(discriminant);
            double solA = (-t + sqrt) / 2;
            double solB = (-t - sqrt) / 2;
            double min = Math.Min(solA, solB);
            double max = Math.Max(solA, solB);

            int resultMin, resultMax;
            if(min % 1 == 0) resultMin = (int)min + 1;
            else resultMin =  (int)Math.Ceiling(min);  

            if(max % 1 == 0) resultMax = (int)max - 1;
            else resultMax =  (int)Math.Floor(max);  

            return (resultMin, resultMax);
            
        }

        protected static int GetNumOfWinningOutcomes(long t, long d) {

            try{
                var (min, max) = GetParabolaLimits(t, d);
                return max - min + 1;
            }
            catch(NegativeDiscriminantException) {
                return 0;
            }
        }

    }

    internal class Part1 : PartSharing {       

        internal static long CalculateMarginError(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            int[] times = [.. lines[0][(lines[0].IndexOf(':')+1)..].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
            int[] distances = [.. lines[1][(lines[1].IndexOf(':')+1)..].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)];
            int[,] racesData = new int[times.Length, 2];
            for(int i = 0; i < times.Length; i++) {
                racesData[i, 0] = times[i];
                racesData[i, 1] = distances[i];
            }

            long result = 1;
            for(int i = 0; i < racesData.GetLength(0); i++) {
                int num = GetNumOfWinningOutcomes(racesData[i, 0], racesData[i, 1]);
                if(num == 0) return 0;

                result *= num;
            }
            
            return result;
        }
    }
}