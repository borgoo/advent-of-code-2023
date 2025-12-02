namespace AdventOfCode2023.Core.Day24; 
 
internal static partial class Day24 { 
 
    internal static class Part2 { 


        private readonly record struct HailStone(long X, long Y, long Z, long Vx, long Vy, long Vz);

        /// <summary>
        /// WARNING: ASSUMING NO HORIZONTAL OR VERTICAL LINES
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        internal static long TailorMadeSolution(string rawText) { 

            const int hailStonesNeededFromAlgebra = 3; // h[0], h[1], h[2]

            string[] lines = rawText.Split(Environment.NewLine);
            HailStone[] hailStones = [..
                    lines.Take(hailStonesNeededFromAlgebra).Select(l => {
                        string[] parts = l.Split(" @ ");
                        long[] positions = [.. parts[0].Split(",").Select(s => long.Parse(s.Trim()))];
                        long[] velocities = [.. parts[1].Split(",").Select(s => long.Parse(s.Trim()))];
                        return new HailStone(positions[0], positions[1], positions[2], velocities[0], velocities[1], velocities[2]);
                    })
            ];

            /**
            * My thrown rock (X,Y,Z) with velocity (Vx,Vy,Vz) must collide with each hailstone (Xh,Yh,Zh) with velocity (Vxh,Vyh,Vzh).
            * For a collision, they must be at the same position at some time t: (X0 + t * Vx)
            * 
            * X + t * Vx = Xh + t * Vxh
            * Y + t * Vy = Yh + t * Vyh
            * Z + t * Vz = Zh + t * Vzh
            *
            * From this system we can express t in three ways:
            * 1. t = (Xh - X) / (Vx - Vxh)
            * 2. t = (Yh - Y) / (Vy - Vyh)
            * 3. t = (Zh - Z) / (Vz - Vzh)
            *
            * Setting equation 1 = equation 2 (since both equal t):
            * (Xh - X) / (Vx - Vxh) = (Yh - Y) / (Vy - Vyh) -->
            * (Xh - X) * (Vy - Vyh) = (Yh - Y) * (Vx - Vxh) -->
            * Xh*Vy - Xh*Vyh - X*Vy + X*Vyh = Yh*Vx - Yh*Vxh - Y*Vx + Y*Vxh -->
            * Y*Vx - X*Vy = Y*Vxh - Yh*Vxh + Yh*Vx - X*Vyh + Xh*Vyh - Xh*Vy
            * 
            * KEY INSIGHT: The left side (Y*Vx - X*Vy) is constant for ALL hailstones!
            * So for two different hailstones (h1 and h2), their right-hand sides must be equal:
            * 
            * Y*Vxh1 - Yh1*Vxh1 + Yh1*Vx - X*Vyh1 + Xh1*Vyh1 - Xh1*Vy = 
            * Y*Vxh2 - Yh2*Vxh2 + Yh2*Vx - X*Vyh2 + Xh2*Vyh2 - Xh2*Vy
            * 
            * Rearranging into standard form (grouping by unknowns X, Y, Vx, Vy):
            * (Vyh2 - Vyh1)*X + (Vxh1 - Vxh2)*Y + (Yh1 - Yh2)*Vx + (Xh2 - Xh1)*Vy = 
            *     Xh2*Vyh2 - Yh2*Vxh2 - Xh1*Vyh1 + Yh1*Vxh1
            * 
            * This is ONE linear equation with our 6 unknowns (X, Y, Z, Vx, Vy, Vz).
            * 
            * Similarly, equating (1 & 3) gives us an equation with X, Z, Vx, Vz.
            * And equating (2 & 3) gives us an equation with Y, Z, Vy, Vz.
            * 
            * From ONE PAIR of hailstones, we get 3 equations.
            * Using TWO PAIRS (3 hailstones total: h0 with h1, and h0 with h2), we get 6 equations.
            * 
            * We can then solve this 6x6 system of linear equations using Gaussian elimination.
            *
            */

            // Build 6x7 matrix (6 equations, 6 unknowns + 1 constant column)
            // Variables order: X, Y, Z, Vx, Vy, Vz
            const int numberOfEquations = 6;
            const int numberOfVariables = 7;
            decimal[,] linearSystemMatrix = new decimal[numberOfEquations, numberOfVariables];
            int row = 0;
            
            // First pair: hailstones[0] with hailstones[1]
            HailStone h1 = hailStones[0];
            HailStone h2 = hailStones[1];   
            FillRow(linearSystemMatrix, row++, GetCoefficientsXY(h1, h2, numberOfVariables));
            FillRow(linearSystemMatrix, row++, GetCoefficientsXZ(h1, h2, numberOfVariables));
            FillRow(linearSystemMatrix, row++, GetCoefficientsYZ(h1, h2, numberOfVariables));
            
            // Second pair: hailstones[0] with hailstones[2]
            HailStone h3 = hailStones[2];
            FillRow(linearSystemMatrix, row++, GetCoefficientsXY(h1, h3, numberOfVariables));
            FillRow(linearSystemMatrix, row++, GetCoefficientsXZ(h1, h3, numberOfVariables));
            FillRow(linearSystemMatrix, row++, GetCoefficientsYZ(h1, h3, numberOfVariables));

            (long X, long Y, long Z) = SolveLinearSystemWithGaussianElimination(linearSystemMatrix, numberOfEquations, numberOfVariables);
            
            
            return X + Y + Z;
        }

        /// <summary>
        /// Equation: (Vyh2 - Vyh1)*X + (Vxh1 - Vxh2)*Y + 0*Z + (Yh1 - Yh2)*Vx + (Xh2 - Xh1)*Vy + 0*Vz = constant part
        /// </summary>
        private static decimal[] GetCoefficientsXY(HailStone h1, HailStone h2, int numberOfVariables) {
            decimal[] coeffs = new decimal[numberOfVariables];
            coeffs[0] = h2.Vy - h1.Vy;  // X coefficient
            coeffs[1] = h1.Vx - h2.Vx;  // Y coefficient
            coeffs[2] = 0;               // Z coefficient
            coeffs[3] = h1.Y - h2.Y;     // Vx coefficient
            coeffs[4] = h2.X - h1.X;     // Vy coefficient
            coeffs[5] = 0;               // Vz coefficient
            coeffs[6] = h2.X * h2.Vy - h2.Y * h2.Vx - h1.X * h1.Vy + h1.Y * h1.Vx;  // constant part
            return coeffs;
        }

        /// <summary>
        /// Equation: (Vzh2 - Vzh1)*X + 0*Y + (Vxh1 - Vxh2)*Z + (Zh1 - Zh2)*Vx + 0*Vy + (Xh2 - Xh1)*Vz = constant part
        /// </summary>
        private static decimal[] GetCoefficientsXZ(HailStone h1, HailStone h2, int numberOfVariables) {
            decimal[] coeffs = new decimal[numberOfVariables];
            coeffs[0] = h2.Vz - h1.Vz;  // X coefficient
            coeffs[1] = 0;               // Y coefficient
            coeffs[2] = h1.Vx - h2.Vx;  // Z coefficient
            coeffs[3] = h1.Z - h2.Z;     // Vx coefficient
            coeffs[4] = 0;               // Vy coefficient
            coeffs[5] = h2.X - h1.X;     // Vz coefficient
            coeffs[6] = h2.X * h2.Vz - h2.Z * h2.Vx - h1.X * h1.Vz + h1.Z * h1.Vx;  // constant part
            return coeffs;
        }

        /// <summary>
        /// Equation: 0*X + (Vzh1 - Vzh2)*Y + (Vyh2 - Vyh1)*Z + 0*Vx + (Zh2 - Zh1)*Vy + (Yh1 - Yh2)*Vz = constant part
        /// </summary>
        private static decimal[] GetCoefficientsYZ(HailStone h1, HailStone h2, int numberOfVariables) {
            decimal[] coeffs = new decimal[numberOfVariables];
            coeffs[0] = 0;               // X coefficient
            coeffs[1] = h1.Vz - h2.Vz;  // Y coefficient
            coeffs[2] = h2.Vy - h1.Vy;  // Z coefficient
            coeffs[3] = 0;               // Vx coefficient
            coeffs[4] = h2.Z - h1.Z;     // Vy coefficient
            coeffs[5] = h1.Y - h2.Y;     // Vz coefficient
            coeffs[6] = -h2.Y * h2.Vz + h2.Z * h2.Vy + h1.Y * h1.Vz - h1.Z * h1.Vy;  // constant part
            return coeffs;
        }

        private static void FillRow(decimal[,] matrix, int row, decimal[] coeffs) {
            for (int col = 0; col < coeffs.Length; col++) {
                matrix[row, col] = coeffs[col];
            }
        }

        /// <summary>
        /// Use pivoting
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="numberOfEquations"></param>
        /// <param name="numberOfVariables"></param>
        /// <returns></returns>
        private static (long X, long Y, long Z) SolveLinearSystemWithGaussianElimination(decimal[,] matrix, int numberOfEquations, int numberOfVariables) {
            

            for (int i = 0; i < numberOfEquations; i++) {
  
                int maxRow = i;
                for (int k = i + 1; k < numberOfEquations; k++) 
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i])) maxRow = k;
                


                for (int k = i; k < numberOfVariables; k++) 
                    (matrix[i, k], matrix[maxRow, k]) = (matrix[maxRow, k], matrix[i, k]);
                


                for (int k = i + 1; k < numberOfEquations; k++) {
                    decimal factor = matrix[k, i] / matrix[i, i];
                    for (int j = i; j < numberOfVariables; j++) {
                        if (i == j)matrix[k, j] = 0;
                        else matrix[k, j] -= factor * matrix[i, j];
                    }
                }
            }

            // Back substitution
            decimal[] solution = new decimal[numberOfEquations];
            for (int i = numberOfEquations - 1; i >= 0; i--) {
                solution[i] = matrix[i, numberOfVariables - 1];
                for (int j = i + 1; j < numberOfEquations; j++) {
                    solution[i] -= matrix[i, j] * solution[j];
                }
                solution[i] /= matrix[i, i];
            }

            long X = (long)Math.Round(solution[0]);
            long Y = (long)Math.Round(solution[1]);
            long Z = (long)Math.Round(solution[2]);

            return (X, Y, Z);
        } 

    } 
}
