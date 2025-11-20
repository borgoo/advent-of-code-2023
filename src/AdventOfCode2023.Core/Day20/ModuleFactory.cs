namespace AdventOfCode2023.Core.Day20;

internal static partial class Day20
{
    internal abstract partial class PartShared
    {

        public static class ModuleFactory
        {

            public static (string id, Module module) CreateModule(string leftData)
            {

                if (leftData == "broadcaster") return (leftData, new BroadcastModule());
                if (leftData[0] == '%') return (leftData[1..], new FlipFlopModule());
                if (leftData[0] == '&') return (leftData[1..], new ConjunctionModule());
                throw new NotImplementedException(leftData);

            }
        }
    }
}
