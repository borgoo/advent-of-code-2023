using System.Text;

namespace AdventOfCode2023.Core.Day25; 
 
internal static partial class Day25 { 
 
    internal static class Part1 { 

        private const string _prefix = "digraph Nodes { layout=neato; nodesep=1.5; ranksep=1.5;";
        private const string _suffix = "}";


        private static (Dictionary<string, HashSet<string>> graph, string dotTemplate) ManageInput(string rawText) {

            IEnumerable<(string left, string[] right)> input = rawText.Split(Environment.NewLine)
                        .Select(line => line.Split(':'))
                        .Select(parts => (parts[0], parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)));

            Dictionary<string, HashSet<string>> graph = [];
            StringBuilder sb = new();
            sb.AppendLine(_prefix);
            foreach ((string left, string[] right) in input) {
                if(!graph.ContainsKey(left)) graph.Add(left, []);
                foreach(string to in right) {
                    sb.AppendLine($"    \"{left}\" -> \"{to}\";");
                    if(!graph.ContainsKey(to)) graph.Add(to, []);
                    graph[to].Add(left);
                    graph[left].Add(to);    
                }
            }
            sb.AppendLine(_suffix);

            return (graph, sb.ToString());        

        }

        private static void Dfs(Dictionary<string, HashSet<string>> graph, string currPoint, HashSet<(string, string)> wireToCut, HashSet<string> seen) {
            
            foreach(string nextPoint in graph[currPoint]) {
                if(seen.Contains(nextPoint) || wireToCut.Contains( ( currPoint, nextPoint) ) ) continue;
                seen.Add(nextPoint);
                Dfs(graph, nextPoint, wireToCut, seen);
            }
        }

        private static long MultiplyTheCardinalityOfTheTwoSets(HashSet<(string, string)> wiresToCut, string[] startingPoints, Dictionary<string, HashSet<string>> graph) {

            foreach (var (from, to) in wiresToCut.ToList()) wiresToCut.Add((to, from));

            HashSet<string> leftNodes = [startingPoints[0]];
            Dfs(graph, startingPoints[0], wiresToCut, leftNodes);

            HashSet<string> rightNodes = [startingPoints[1]];
            Dfs(graph, startingPoints[1], wiresToCut, rightNodes);

            return leftNodes.Count * rightNodes.Count;

        }

        internal static long TailorMadeSampleInput(string rawText) { 

            var (graph, dotTemplate) = ManageInput(rawText);
            // GO TO: https://dreampuf.github.io/GraphvizOnline/?engine=dot
            // copy paste the dotTemplate: 
            // Console.WriteLine(dotTemplate)

            // from the website I've identified 3 wires to cut
            HashSet<(string, string)> wiresToCut = [
                ("hfx","pzl"),
                ("bvb","cmg"),
                ("nvd","jqt"),
            ];          

            // I've identified two starting points as well
            string[] startingPoints = ["ntq","rzs"];

            return MultiplyTheCardinalityOfTheTwoSets(wiresToCut, startingPoints, graph);

         

        }

        internal static long TailorMadePuzzleInput(string rawText) {

            var (graph, dotTemplate) = ManageInput(rawText);
            // GO TO: https://dreampuf.github.io/GraphvizOnline/?engine=dot
            // copy paste the dotTemplate: 
            // Console.WriteLine(dotTemplate)

            // from the website I've identified 3 wires to cut
            HashSet<(string, string)> wiresToCut = [
                ("xgs","lmj"),
                ("hgk","pgz"),
                ("qnz","gzr"),
            ];          

            // I've identified two starting points as well
            string[] startingPoints = ["xgs","rkd"];

            return MultiplyTheCardinalityOfTheTwoSets(wiresToCut, startingPoints, graph);
        }
    }
}
