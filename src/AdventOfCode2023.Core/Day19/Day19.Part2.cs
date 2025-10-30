namespace AdventOfCode2023.Core.Day19; 
 
internal static partial class Day19 { 
 
    internal class Part2 : PartShared { 

        private const int _maxValue = 4000;
        private const int _minValue = 1;

        private static readonly Dictionary<char, int> _categoryToIndex = new() {
            {'x', 0},
            {'m', 1},
            {'a', 2},
            {'s', 3}
        };

        private record struct CategoryRange(char Variable, int Min, int Max);

        private abstract class BaseRangeCondition(string conditionAsString) : BaseCondition<CategoryRange[]>(conditionAsString) {
            protected int Index {get; init;}
            internal abstract void Complement(CategoryRange[] variables);
        }

        private class DirectGoToLabelRangeCondition(string conditionAsString) :BaseRangeCondition(conditionAsString)
        {
            internal override void Complement(CategoryRange[] variables)
            {
                //do nothing
            }

            internal override string? Result(CategoryRange[] variables)
            {
                return GoToLabel;
            }
        }

        private class LessThanRangeCondition : BaseRangeCondition
        {            
            internal LessThanRangeCondition(string conditionAsString) : base(conditionAsString){
                Index = _categoryToIndex[_varName!.Value];
            }

            internal override string? Result(CategoryRange[] variables)
            {
                if(_thresholdValue < variables[Index].Min) return null;
                
                variables[Index] = new CategoryRange(_varName!.Value, 
                    variables[Index].Min,
                    Math.Min(_thresholdValue!.Value -1, variables[Index].Max)
                );
                return GoToLabel;

            }

            internal override void Complement(CategoryRange[] variables)
            {
                variables[Index] = new CategoryRange(_varName!.Value, 
                    Math.Max(_thresholdValue!.Value, variables[Index].Min),
                    variables[Index].Max
                );
                
            }
        }

        private class GreaterThanRangeCondition : BaseRangeCondition
        {
            internal GreaterThanRangeCondition(string conditionAsString) : base(conditionAsString){
                Index = _categoryToIndex[_varName!.Value];
            }
            
            internal override string? Result(CategoryRange[] variables)
            {
                if(_thresholdValue > variables[Index].Max) return null;
                variables[Index] = new CategoryRange(_varName!.Value, 
                    Math.Max(_thresholdValue!.Value + 1, variables[Index].Min),
                    variables[Index].Max
                );
                return GoToLabel;

            }

            
            internal override void Complement(CategoryRange[] variables)
            {
                variables[Index] = new CategoryRange(_varName!.Value, 
                    variables[Index].Min,
                    Math.Min(_thresholdValue!.Value, variables[Index].Max)
                );
            }
        }

        private record RangeWorkflow(string key, string[] conditionsAsStrings) : BaseWorkflow<BaseRangeCondition>(key, conditionsAsStrings)
        {
            protected override BaseRangeCondition ConditionBuilder(string conditionAsString)
            {
                if(conditionAsString.Contains('<')) {
                    return new LessThanRangeCondition(conditionAsString);
                }
                else if(conditionAsString.Contains('>')) {
                    return new GreaterThanRangeCondition(conditionAsString);
                }
                else{
                    return new DirectGoToLabelRangeCondition(conditionAsString);
                }
            }
        }

        private static Dictionary<string, RangeWorkflow> BuildExpressionTree(string rawGraph)
        {
            Dictionary<string, RangeWorkflow> graph = [];
            string[] lines = rawGraph.Split(Environment.NewLine);
            foreach(string line in lines) {
                int specialChar = line.IndexOf('{');
                string key = line[..specialChar];
                string nodeAsString = line[(specialChar+1)..^1];
                string[] conditions = nodeAsString.Split(',');
                graph.Add(key, new RangeWorkflow(key, conditions));
            }
            return graph;
        }   

        private static long ProdOfRatingNumbers(CategoryRange[] variables) {
            long prod = 1;
            foreach(var variable in variables) {
                prod *= variable.Max - variable.Min +1;
            }
            return prod;
        }


        private static void Dfs(
            Dictionary<string, RangeWorkflow> graph, 
            CategoryRange[] variables, 
            RangeWorkflow currWorkflow,
            int currConditionIndex, 
            ref long sum
        ) {

            BaseRangeCondition condition = currWorkflow.Conditions[currConditionIndex];

            CategoryRange[] variablesForTrueBranch = (CategoryRange[])variables.Clone();
            string? nextKey = condition.Result(variablesForTrueBranch);
            if(nextKey is not null) {
                if(nextKey == _acceptedKey) {
                    sum += ProdOfRatingNumbers(variablesForTrueBranch);
                } else if(nextKey == _rejectedKey) {
                } else {
                    Dfs(graph, variablesForTrueBranch, graph[nextKey], 0, ref sum);
                }
            }

            if(currConditionIndex + 1 < currWorkflow.Conditions.Length) {
                CategoryRange[] variablesForFalseBranch = (CategoryRange[])variables.Clone();
                condition.Complement(variablesForFalseBranch);
                Dfs(graph, variablesForFalseBranch, currWorkflow, currConditionIndex + 1, ref sum);
            }

        }

        private static long NavigateExpressionTree(Dictionary<string, RangeWorkflow> graph) {

            CategoryRange[] variables = new CategoryRange[_categoryToIndex.Count];
            foreach(var category in _categoryToIndex) {
                variables[category.Value] = new CategoryRange(category.Key, _minValue, _maxValue);
            }
 
            long sum = 0;
            Dfs(graph, variables, graph[_startingKey], 0, ref sum);
            return sum;
        }

        internal static long GetNumOfDistinctCombinationsThatWillBeAccepted(string rawText) { 
 
            string[] tmp = rawText.Split(Environment.NewLine + Environment.NewLine);
            Dictionary<string, RangeWorkflow> graph = BuildExpressionTree(tmp[0]);
            long sum = NavigateExpressionTree(graph);

            return sum;
        } 
 
    } 
} 
