namespace AdventOfCode2023.Core.Day19; 

internal static partial class Day19 {

    internal abstract partial class PartShared {

        protected abstract record BaseWorkflow<TOutput> where TOutput : notnull {
            internal string Key {get; init;}
            internal TOutput[] Conditions {get; init;}

            protected abstract TOutput ConditionBuilder(string conditionAsString);

            internal BaseWorkflow(string key, string[] conditionsAsStrings) {
                Key = key;
                Conditions = new TOutput[conditionsAsStrings.Length];
                for(int i = 0; i < conditionsAsStrings.Length; i++) {
                    Conditions[i] = ConditionBuilder(conditionsAsStrings[i]);
                }
            }

        }

        protected abstract class BaseCondition<TInput> where TInput : notnull
        {
            protected char? _varName = null;
            protected int? _thresholdValue = null;
            protected string GoToLabel {get; init;}

            /// <summary>
            /// Compute the Condition
            /// </summary>
            /// <param name="input"></param>
            /// <returns>The goto label or null if the condition is not met.</returns>
            internal abstract string? Result(TInput input);


            internal BaseCondition(string conditionAsString) {
                if(!conditionAsString.Contains(':')){
                    GoToLabel = conditionAsString;
                    return;
                }

                string[] parts = conditionAsString.Split(':');
                GoToLabel = parts[1];
                _varName = parts[0][0];
                _thresholdValue = int.Parse(parts[0][2..]);
                if(_varName is null || _thresholdValue is null) throw new NullReferenceException();
            }
        }

    }
}