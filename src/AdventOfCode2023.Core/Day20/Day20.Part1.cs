using System.Reflection;

namespace AdventOfCode2023.Core.Day20; 


internal static partial class Day20 {

    internal abstract partial class PartShared
    {
        public enum SignalEnum
        {
            Low = 0,
            High = 1
        }

    }

    internal partial class Part1 : PartShared
    {

        private const int _defaultPushes = 1000;

        internal static long GetTotalMulOfHighAndLowPulses(string rawText, int pushes = _defaultPushes)
        {

            Circuit circuit = new(rawText);
            CircuitResult result = new();
            for (int i = 0; i < pushes; i++)
            {
                CircuitResult current = circuit.PushTheButton();
                result.AddOtherResult(current);

            }
            return result.Get();

        }


    }
 
} 
