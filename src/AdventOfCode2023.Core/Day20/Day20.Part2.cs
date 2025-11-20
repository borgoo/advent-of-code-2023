using System.Text;

namespace AdventOfCode2023.Core.Day20;

internal static partial class Day20 {

    internal partial class Part2 : PartShared{

        internal class  DOTTemplateCircuit {

            const string _prefix = "digraph Circuit {";
            const string _suffix = "}";
            private readonly string _dotTemplate;
            public DOTTemplateCircuit(string rawText) {

                string tmp = rawText.Replace("%", "").Replace("&", "");
                var lines = tmp.Split(Environment.NewLine);
                StringBuilder sb = new();
                sb.AppendLine(_prefix);
                foreach (var line in lines) {
                    string[] parts = line.Split(" -> ");
                    foreach(string right in parts[1].Split(", ")) {
                        sb.AppendLine($"    \"{parts[0]}\" -> \"{right}\";");
                    }
                }
                sb.AppendLine(_suffix);

                _dotTemplate = sb.ToString();

            }

            public string Get() => _dotTemplate;

        }


        internal static long FindLCMForSubCircuitsHighOutputSignal(string rawText)
        {

            DOTTemplateCircuit dotTemplate = new(rawText);
            string toBePasted = dotTemplate.Get();
            // GO TO: https://dreampuf.github.io/GraphvizOnline/?engine=dot

            //from the website I've identified 4 sub-circuits that must output HIGH to reduce rx to LOW
            int numOfSubCircuits = 4;   
            int[] results = new int[numOfSubCircuits];
            (string outputModule, HashSet<string> subCircuit)[] subCircuits = [
                ("dg",["broadcaster","hs","sl","xq","zl","nt","nj","cx","pt","qh","gt","ln","hg","mq","sp","dg"]),
                ("dg",["broadcaster","rc","rm","dm","dv","bl","xt","jt","vp","fd","td","hx","gf","dc","nv","dg"]),
                ("dg",["broadcaster","mg","hl","qb","cd","jc","lk","ps","xc","kz","mc","xv","tx","rv","tp","dg"]),
                ("dg",["broadcaster","kx","sg","vv","zv","tr","br","jq","mm","vh","xx","cz","lc","vn","cc","dg"])
            ];

            for (int i = 0; i < numOfSubCircuits; i++)
            {
                Circuit circuit = new(rawText, subCircuits[i]);
                int tmp = circuit.PushTheButtonUntilTheDesignedModuleIsHigh();
                results[i] = tmp;
            }


            long lcm = Day8.MathUtils.LCM(results);
            return lcm;

        }

    } 
} 
