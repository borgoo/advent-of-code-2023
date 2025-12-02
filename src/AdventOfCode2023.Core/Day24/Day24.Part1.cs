namespace AdventOfCode2023.Core.Day24; 
 
internal static partial class Day24 { 
 
    internal static class Part1 { 

        private const long _defaultTestAreaMin = 200_000_000_000_000;
        private const long _defaultTestAreaMax = 400_000_000_000_000;

        private readonly record struct HailStoneWithoutZ {
            internal readonly long X {get; init;}
            internal readonly long Y {get; init;}
            internal readonly decimal Dx {get; init;}
            internal readonly decimal Vx {get; init;}
            internal readonly decimal Dy {get; init;}
            internal readonly decimal Vy {get; init;}
            internal readonly decimal M {get; init;}
            internal readonly decimal Q {get; init;}
            
            public HailStoneWithoutZ(long X, long Y, long Vx, long Vy) {
                this.X = X;
                this.Y = Y;
                this.Vx = Vx;
                this.Vy = Vy;
                Dx = Vx;
                Dy = Vy;
                M = (decimal)Vy / Vx;  
                Q = Y - (M * X); 
            }
        }

        /// <summary>
        /// WARNING: ASSUMING NO HORIZONTAL OR VERTICAL LINES
        /// </summary>
        /// <param name="rawText"></param>
        /// <param name="testAreaMin"></param>
        /// <param name="testAreaMax"></param>
        /// <returns></returns>
 
        internal static long CountNumOfIntersections(string rawText, long testAreaMin = _defaultTestAreaMin, long testAreaMax = _defaultTestAreaMax) { 

            string[] lines = rawText.Split(Environment.NewLine);
            HailStoneWithoutZ[] hailStones = [..
                    lines.Select(l => {
                        string[] parts = l.Split(" @ ");
                        long[] positions = [.. parts[0].Split(",").Select(s => long.Parse(s.Trim()))];
                        long[] velocities = [.. parts[1].Split(",").Select(s => long.Parse(s.Trim()))];
                        return new HailStoneWithoutZ(positions[0], positions[1], velocities[0], velocities[1]);
                    })
            ];


            int count = 0;
            for(int i = 0; i < hailStones.Length -1; i++) {

                HailStoneWithoutZ h1 = hailStones[i];
                for(int j = i + 1; j < hailStones.Length; j++) {
                    HailStoneWithoutZ h2 = hailStones[j];
                    
                    if(h1.M == h2.M) continue;
                    
                    // solve the system
                    decimal finalQ = h1.Q + (-1 * h2.Q);
                    decimal finalM = h1.M + (-1 * h2.M);
                    decimal finalX = -1* finalQ / finalM;
                    if(finalX < testAreaMin || finalX > testAreaMax) continue;
                    decimal finalY = h1.M * finalX + h1.Q;
                    if(finalY < testAreaMin || finalY > testAreaMax) continue;
                   
                    // V = S / T => T = S / V --> S = from P0 to intersection point
                    decimal tIntersectionH1 = (finalX - h1.X) / h1.Vx;
                    if(tIntersectionH1 < 0) continue;
                    decimal tIntersectionH2 = (finalX - h2.X) / h2.Vx;
                    if(tIntersectionH2 < 0) continue;

                    count++;
                }
            }

            return count;

        } 
 
    } 
} 
