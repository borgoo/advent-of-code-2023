namespace AdventOfCode2023.Core.Day20;

internal partial class Day20 {

    internal partial class Part2 : PartShared
    {
        private class Circuit
        {

            const string _startingModuleId = BroadcastModule.Id;

            private readonly Dictionary<string, HashSet<string>> _edges;
            protected readonly Dictionary<string, Module> _nodes;
            private readonly string _designedOutputModule;

            public Circuit(string rawText, (string outputModule, HashSet<string> subCircuit) subCircuitData)
            {
                (Dictionary<string, HashSet<string>> Edges, Dictionary<string, Module> Nodes) = InitializeCircuit(rawText, subCircuitData.subCircuit);
                _edges = Edges;
                _nodes = Nodes;
                _designedOutputModule = subCircuitData.outputModule;
            }

            private static (Dictionary<string, HashSet<string>> Edges, Dictionary<string, Module> Nodes) InitializeCircuit(string rawText, HashSet<string> subcircuit)
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
                    right.IntersectWith(subcircuit);

                    var (id, module) = ModuleFactory.CreateModule(left);
                    if(!subcircuit.Contains(id)) continue;

                    rightModules.UnionWith(right);

                    edges.Add(id, right);
                    nodes.Add(id, module);

                    if (module is ConjunctionModule) conjunctions.Add(id);
                }

                foreach (string rightModuleId in rightModules)
                {
                    if(!subcircuit.Contains(rightModuleId)) continue;
                    if (!nodes.ContainsKey(rightModuleId)) nodes.Add(rightModuleId, new DeadEndModule());
                }

                foreach (string conjunctionId in conjunctions)
                {
                    if (!subcircuit.Contains(conjunctionId)) continue;
                    ConjunctionModule conjunctionModule = (ConjunctionModule)nodes[conjunctionId];

                    foreach (var edge in edges)
                    {
                        if (edge.Value.Contains(conjunctionId)) conjunctionModule.InitStatus(edge.Key);
                    }
                }

                return (edges, nodes);

            }

            internal int PushTheButtonUntilTheDesignedModuleIsHigh() {

                bool found = false;
                int pushes = 0;
                while (!found) {
                    found = PushTheButton();
                    pushes++;
                }

                return pushes;
            
            }


            private bool PushTheButton()
            {
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
                            if (nextModuleId == _designedOutputModule && signal == SignalEnum.High) return true;

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

                return false;
            }

        }


    }




}