namespace AdventOfCode2023.Core.Day20;

internal partial class Day20 {

    internal partial class Part1 : PartShared
    {
        private class CircuitResult
        {
            private readonly long[] _result = new long[2];
            private const int _lowIdx = (int)SignalEnum.Low;
            private const int _highIdx = (int)SignalEnum.High;

            public long Get() => _result[_lowIdx] * _result[_highIdx];
            public long GetLow() => _result[_lowIdx];
            public long GetHigh() => _result[_highIdx];
            public void Increment(SignalEnum signal, int val = 1) => _result[(int)signal] += val;

            public void AddOtherResult(CircuitResult other)
            {
                _result[_lowIdx] += other.GetLow();
                _result[_highIdx] += other.GetHigh();
            }


        }
        private class Circuit
        {

            const string _startingModuleId = BroadcastModule.Id;

            private readonly Dictionary<string, HashSet<string>> _edges;
            protected readonly Dictionary<string, Module> _nodes;

            public Circuit(string rawText)
            {
                (Dictionary<string, HashSet<string>> Edges, Dictionary<string, Module> Nodes) = InitializeCircuit(rawText);
                _edges = Edges;
                _nodes = Nodes;
            }

            private static (Dictionary<string, HashSet<string>> Edges, Dictionary<string, Module> Nodes) InitializeCircuit(string rawText)
            {
                Dictionary<string, HashSet<string>> edges = [];
                Dictionary<string, Module> nodes = [];
                HashSet<string> conjunctions = [];


                string[] lines = rawText.Split(Environment.NewLine);
                HashSet<string> rightModules = [];

                foreach (string line in lines)
                {
                    string[] data = line.Split(" -> ");
                    string left = data[0];
                    HashSet<string> right = [.. data[1].Split(", ")];
                    rightModules.UnionWith(right);

                    var (id, module) = ModuleFactory.CreateModule(left);

                    edges.Add(id, right);
                    nodes.Add(id, module);

                    if (module is ConjunctionModule) conjunctions.Add(id);
                }

                foreach (string rightModuleId in rightModules)
                {
                    if (!nodes.ContainsKey(rightModuleId)) nodes.Add(rightModuleId, new DeadEndModule());
                }

                foreach (string conjunctionId in conjunctions)
                {
                    ConjunctionModule conjunctionModule = (ConjunctionModule)nodes[conjunctionId];

                    foreach (var edge in edges)
                    {
                        if (edge.Value.Contains(conjunctionId)) conjunctionModule.InitStatus(edge.Key);
                    }
                }

                return (edges, nodes);

            }

            internal CircuitResult PushTheButton()
            {

                CircuitResult total = new();
                total.Increment(SignalEnum.Low); // BUTTON MODULE INIT

                Queue<string> queue = [];
                queue.Enqueue(_startingModuleId);

                while (queue.Count > 0)
                {

                    int n = queue.Count;
                    List<Event> levelEvents = [];

                    for (int i = 0; i < n; i++)
                    {

                        string currentModuleId = queue.Dequeue();
                        Module currentModule = _nodes[currentModuleId];
                        SignalEnum signal = currentModule.GetOutputSignal();

                        foreach (string nextModuleId in _edges[currentModuleId])
                        {
                            total.Increment(signal);

                            Event newEvent = new(currentModuleId, nextModuleId, signal);
                            levelEvents.Add(newEvent);

                            Module nextModule = _nodes[nextModuleId];
                            if (nextModule is DeadEndModule) continue;
                            if (nextModule is FlipFlopModule && signal == SignalEnum.High) continue;
                            queue.Enqueue(nextModuleId);
                        }

                    }

                    foreach (Event levelEvent in levelEvents)
                    {
                        _nodes[levelEvent.To].UpdateStatus(levelEvent.From, levelEvent.Signal);
                    }


                }

                return total;
            }

        }


    }




}