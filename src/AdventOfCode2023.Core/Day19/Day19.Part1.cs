using System.Data;

namespace AdventOfCode2023.Core.Day19; 
 
internal static partial class Day19 { 

    internal abstract partial class PartShared {
        protected const string _startingKey = "in";
        protected const string _rejectedKey = "R";
        protected const string _acceptedKey = "A";

    }
 
    internal class Part1 : PartShared {



        private class DirectGoToLabelValueCondition(string conditionAsString) :  BaseCondition<Dictionary<char, int>>(conditionAsString)
        {
            internal override string? Result(Dictionary<char, int> input)
            {
                return GoToLabel;
            }
        }
       
        private class LessThanValueCondition(string conditionAsString) :  BaseCondition<Dictionary<char, int>>(conditionAsString)
        {
            internal override string? Result(Dictionary<char, int> input)
            {
                return input[_varName!.Value] < _thresholdValue!.Value ? GoToLabel : null;
            }
        }
        private class GreaterThanValueCondition(string conditionAsString) :  BaseCondition<Dictionary<char, int>>(conditionAsString)
        {
            internal override string? Result(Dictionary<char, int> input)
            {
                return input[_varName!.Value] > _thresholdValue!.Value ? GoToLabel : null;
            }
        }


        private record ValueWorkflow(string key, string[] conditionsAsStrings) : BaseWorkflow<BaseCondition<Dictionary<char, int>>>(key, conditionsAsStrings)
        {
            protected override BaseCondition<Dictionary<char, int>> ConditionBuilder(string conditionAsString)
            {
                if(conditionAsString.Contains('<')) {
                    return new LessThanValueCondition(conditionAsString);
                }
                else if(conditionAsString.Contains('>')) {
                    return new GreaterThanValueCondition(conditionAsString);
                }
                else{
                    return new DirectGoToLabelValueCondition(conditionAsString);
                }
            }
        }



        private static List<Dictionary<char, int>> BuildInputsForExpressionTree(string rawInputs) {
            
            IEnumerable<int[]> tmp = rawInputs.Split(Environment.NewLine)
                                               .Select(line => line[1..^1]
                                                    .Split(',')
                                                    .Select(input => Convert.ToInt32(input[2..]))
                                                    .ToArray()
                                                );
                                    
            List<Dictionary<char, int>> inputs = [];
            foreach(var input in tmp) {
                Dictionary<char, int> variables = [];
                variables.Add('x', input[0]);
                variables.Add('m', input[1]);
                variables.Add('a', input[2]);
                variables.Add('s', input[3]);
                inputs.Add(variables);
            }
            return inputs;
            
        }

        private static long SumOfRatingNumbers(Dictionary<char, int> variables) => variables.Values.Sum();

        private static long Dfs(Dictionary<string, ValueWorkflow> graph, Dictionary<char, int> variables, string key) {
            ValueWorkflow workflow = graph[key];
            foreach(var condition in workflow.Conditions) {
                string? nextKey = condition.Result(variables);
                if(nextKey is null) continue;
                if(nextKey == _rejectedKey) return 0;
                if(nextKey == _acceptedKey) return SumOfRatingNumbers(variables);
                return Dfs(graph, variables, nextKey);
            }

            throw new InvalidOperationException("Each workflow must terminate with a valid goto key");
            
        }

        private static long NavigateExpressionTree(Dictionary<string, ValueWorkflow> graph, List<Dictionary<char, int>> inputs) {
            long sum = 0;
            string key = _startingKey;
            foreach(var input in inputs) {
                sum += Dfs(graph, input, key);
            }

            return sum;
        }

        private static Dictionary<string, ValueWorkflow> BuildExpressionTree(string rawGraph)
        {
            Dictionary<string, ValueWorkflow> graph = [];
            string[] lines = rawGraph.Split(Environment.NewLine);
            foreach(string line in lines) {
                int specialChar = line.IndexOf('{');
                string key = line[..specialChar];
                string nodeAsString = line[(specialChar+1)..^1];
                string[] conditions = nodeAsString.Split(',');
                graph.Add(key, new ValueWorkflow(key, conditions));
            }
            return graph;
        }
 
        internal static long SumAllRatingNumbersOfAcceptedParts(string rawText) { 
 
            string[] tmp = rawText.Split(Environment.NewLine + Environment.NewLine);
            List<Dictionary<char, int>> inputs = BuildInputsForExpressionTree(tmp[1]);
            Dictionary<string, ValueWorkflow> graph = BuildExpressionTree(tmp[0]);
            long sum = NavigateExpressionTree(graph, inputs);

            return sum;


        }

      
    } 
} 
